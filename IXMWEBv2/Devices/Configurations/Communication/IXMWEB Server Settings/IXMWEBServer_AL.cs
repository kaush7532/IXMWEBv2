using IXMWEBv2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXMWEBv2.Devices.Configurations.Communication.IXMWEB_Server_Settings
{
    public class IXMWEBServer_AL
    {
        public Communication_PO commpo;
        public IXMWEBServer_PO ixmwebserverpo;

        public IXMWEBServer_AL()
        {
            commpo = new Communication_PO();
            ixmwebserverpo = new IXMWEBServer_PO();
            commpo.ShowIXMWEBServerSettings(true);
        }

        /// <summary>
        /// Method to get IXMWEB SErver URL
        /// </summary>
        /// <returns>URL value</returns>
        public string GetIXMServerURL()
        {
            string url = null;
            try
            {
                //Expand IXMWEB Server
                commpo.ShowIXMWEBServerSettings();

                //Get URL
                url = ixmwebserverpo.GetIXMWEBServerURL();

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to get IXMWEB Server URL value");
                throw new Exception("Failed to get IXMWEB Server URL in access layer");
            }
            return url;
        }

        /// <summary>
        /// Method to set IXMWEB Server URL
        /// </summary>
        /// <param name="urlValue">value to set</param>
        /// <returns>model details</returns>
        public IXMWEBServerURLModel SetIXMWEBServerURL(string urlValue)
        {
            IXMWEBServerURLModel model;
            try
            {
                //Expand settings
                commpo.ShowIXMWEBServerSettings();
                //Enter value
                ixmwebserverpo.EnterIXMWEBServerURL(urlValue);
                //Click apply
                model = ixmwebserverpo.ClickApply();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Set IXMWEBServer URL from access layer");
                throw new Exception("Failed to Set IXMWEB Server URL");
            }
            return model;
        }


    }
}
