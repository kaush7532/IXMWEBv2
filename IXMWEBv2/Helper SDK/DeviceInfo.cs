﻿using IXMSoft.Business.SDK;
using IXMSoft.Business.SDK.Data;
using IXMSoft.Business.SDK.IXMException;
using IXMWEBv2.Utils;
using IXMWEBv2.WebDriverFactory;
using System;
using System.Net.Sockets;
using System.Threading;

namespace IXMWEBv2.Helper_SDK
{
    public abstract class DeviceInfo
    {
        protected NetworkConnection nc { get; set; }
        protected DeviceInfoManager dim { get; set; }
        protected NetworkConfigurationManager ncm { get; set; }

        public DeviceInfo()
        {
            Logger.Info("SDK: Initializing device network connection");
            Initialize(DriverManager.onlineDeviceIP, DriverManager.onlineDevicePort, DeviceConnectionType.Ethernet);
        }

        /// <summary>
        /// Method to initialize network connection, configuration and deviceinfomanager class
        /// </summary>
        /// <param name="ipAddress">IPAddress value</param>
        /// <param name="port">Port value</param>
        /// <param name="connectionType">DeviceConnectionType</param>
        protected void Initialize(string ipAddress, string port, DeviceConnectionType connectionType)
        {
            try
            {
                nc = new NetworkConnection();

                nc.DeviceSettings.IPaddress = ipAddress;
                nc.DeviceSettings.Port = port;
                nc.DeviceSettings.ConnectionType = connectionType;
                nc.ReceiveTimeout = 1200000;
                nc.SendTimeout = 600000;

                Logger.Info("Starting Wait Connection");

                if (WaitForConnection(ipAddress, Convert.ToInt16(port), 15, 10))
                {
                    nc.OpenConnection();
                    Logger.Info(nc.IsOpen.ToString() + nc.DeviceSettings.Port + nc.DeviceSettings.IPaddress);

                    ncm = new NetworkConfigurationManager(nc);
                    Logger.Info(ncm.RetrieveEthernetNetworkSettings().IPAddress.ToString() + ncm.RetrieveEthernetNetworkSettings().Port.ToString());

                    dim = new DeviceInfoManager(nc);
                    Logger.Info("SDK: Initialize success for IP: " + ipAddress + " and PORT: " + port);
                }
                else
                {
                    throw new Exception("SDK: Failed to initialize network connection. Socket unavailable");
                }
            }
            catch (IXMSDKException ex)
            {
                Logger.Error(ex, "SDK: SDKException");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to initialize methods for sdk for IP: " + ipAddress + " and PORT: " + port);
                throw;
            }
        }

        private bool WaitForConnection(string ipAddress, int port, int retryAfterSeconds, int numberOfRetries)
        {
            TcpClient client = new TcpClient();
            bool isConnected = false;
            for (int i = 0; i < numberOfRetries; i++)
            {
                var result = client.BeginConnect(ipAddress, port, null, null);

                // give the client 15 seconds to connect
                result.AsyncWaitHandle.WaitOne(retryAfterSeconds * 1000);

                if (!client.Connected)
                {
                    try
                    {
                        client.EndConnect(result);
                    }
                    catch (SocketException ex)
                    {
                        Logger.Error(ex, "SDK: Connection Failed iteration: " + i);
                    }

                    string message = "There was an error connecting to the server ... {0}";

                    if (i == numberOfRetries)
                    {
                        Logger.Info("aborting " + message);
                        isConnected = false;
                    }
                    else
                    {
                        Logger.Info("retrying " + message);
                        Thread.Sleep(retryAfterSeconds * 1000);
                    }

                    continue;
                }

                break;
            }

            if (client.Connected)
            {
                Console.WriteLine("The client is connected to the server...");
                isConnected = true;
            }
            return isConnected;
        }
    }
}
