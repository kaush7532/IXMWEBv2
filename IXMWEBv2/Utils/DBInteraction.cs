using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using IXMWEBv2.Models.DBModels;
using IXMWEBv2.WebDriverFactory;

namespace IXMWEBv2.Utils
{
    public class DBInteraction
    {
        private string connString;
        private SqlConnection conn;

        public DeviceInfo onlineDeviceInfo;
        public DeviceInfo offlineDeviceInfo;
        public static List<DeviceInfo> listOfDevicesTreefromDb;

        public object UserGroupID { get; private set; }

        public DBInteraction()
        {
            connString = DriverManager.connectionString;
            if (onlineDeviceInfo == null)
            {
                onlineDeviceInfo = GetDeviceDetailsFromDB(DriverManager.onlineDeviceIP);
                DriverManager.onlineDeviceIP = onlineDeviceInfo.IpAddress;
                DriverManager.onlineDeviceName = onlineDeviceInfo.DeviceName;
                DriverManager.onlineDevicePort = Convert.ToString(onlineDeviceInfo.Port);
            }
            //if (offlineDeviceInfo == null)
            //{
            //    offlineDeviceInfo = GetDeviceDetailsFromDB(DriverManager.offlineDeviceIP);
            //    DriverManager.onlineDeviceIP = onlineDeviceInfo.IpAddress;
            //    DriverManager.onlineDeviceName = onlineDeviceInfo.DeviceName;
            //    DriverManager.onlineDevicePort = onlineDeviceInfo.Port;
            //}
            if (listOfDevicesTreefromDb == null)
            {
                string[] deviceIps = DriverManager.devicesOfTreeView.Split(',');
                listOfDevicesTreefromDb = new List<DeviceInfo>();
                foreach (var ip in deviceIps)
                {
                    var de = GetDeviceDetailsFromDB(ip);
                    listOfDevicesTreefromDb.Add(de);
                }
            }
        }

        #region Device related Db methods

        /// <summary>
        /// Method gets devicedetails from database and sets to DeviceInfoModel class
        /// </summary>
        /// <param name="deviceName">device name in current db</param>
        /// <returns></returns>
        public DeviceInfo GetDeviceDetailsFromDB(string ipAddress)
        {
            try
            {
                ipAddress = ipAddress.Trim();
                DeviceInfo deviceInfo = new DeviceInfo();

                DataTable dt = new DataTable();
                string query = "select [Name],[Port],[IPaddress],[SerialNumber] from [Device] where IPaddress=@param1" +
                    " OR WiFiIPAddress =@param1 OR GSMIPAddress=@param1";
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@param1", ipAddress);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    conn.Close();
                }
                if (dt != null && dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    deviceInfo.Port = Convert.ToUInt32(dr["Port"]);
                    deviceInfo.IpAddress = ipAddress;
                    deviceInfo.DeviceName = dr["Name"].ToString();
                    deviceInfo.SerialNo = dr["SerialNumber"].ToString();
                    Logger.Info("DATABASE: Found device in database with IP: " + deviceInfo.IpAddress + " and Port: " + deviceInfo.Port + " and DeviceName: " + deviceInfo.DeviceName);
                }
                else
                {
                    Logger.Info("DATABASE: No device found with IP: " + ipAddress);
                    throw new Exception("DATABASE: No device found from database with IP: " + ipAddress);
                }

                return deviceInfo;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "DATABASE: Get device details from database failed");
                throw;
            }
        }

        /// <summary>
        /// Method gets devicedetails from database and sets to DeviceInfoModel class
        /// </summary>
        /// <param name="deviceName">device name in current db</param>
        /// <returns></returns>
        public List<DeviceInfo> GetDetailsOfAllDevicesFromDB()
        {
            try
            {
                List<DeviceInfo> dInfoList = new List<DeviceInfo>();

                DataTable dt = new DataTable();
                string query = "select [Name],[Port],[IPaddress] from [Device];";
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    //cmd.Parameters.AddWithValue("@param1", ipAddress);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dt);
                    conn.Close();
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    dInfoList = (from DataRow dr in dt.Rows
                                 select new DeviceInfo()
                                 {
                                     DeviceName = dr["Name"].ToString(),
                                     IpAddress = dr["IPaddress"].ToString(),
                                     Port = Convert.ToUInt32(dr["Port"])
                                 }).ToList();

                    //foreach (DataRow item in dt.Rows)
                    //{
                    //    //DataRow dr = dt.Rows[item];

                    //    dInfoList.Add(new DeviceInfoFromDB
                    //    {
                    //        DeviceName = item["Name"].ToString(),
                    //        IpAddress = item["IPaddress"].ToString(),
                    //        Port = item["Port"].ToString()
                    //    });

                    //    //Logger.Info("DATABASE: Found device in database with IP: " + deviceInfo.IpAddress + " and Port: " + deviceInfo.Port + " and DeviceName: " + deviceInfo.DeviceName);

                    //    //dInfoList.Add(deviceInfo);
                    //}
                    //DataRow dr = dt.Rows[0];
                    //deviceInfo.Port = dr["Port"].ToString();
                    //deviceInfo.IpAddress = dr["IPaddress"].ToString();
                    //deviceInfo.DeviceName = dr["Name"].ToString();
                    //Logger.Info("DATABASE: Found device in database with IP: " + deviceInfo.IpAddress + " and Port: " + deviceInfo.Port + " and DeviceName: " + deviceInfo.DeviceName);
                }
                else
                {
                    throw new Exception("DATABASE: No device found from database with IP: ");
                }

                return dInfoList;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "DATABASE: Get device details from database failed");
                throw;
            }
        }

        /// <summary>
        /// Method to delete device entry from database along with all its references
        /// </summary>
        /// <param name="deviceIp">value of deviceIP</param>
        public void DeleteDeviceFromDb(string deviceIp)
        {
            try
            {
                string query1 = "select dbid from device where ipaddress = @param1 or wifiipaddress= @param1";
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand()
                    {
                        Connection = conn,
                        CommandText = query1
                    };
                    cmd.Parameters.AddWithValue("@param1", deviceIp);

                    var dbid = cmd.ExecuteScalar();
                    string db = string.Empty;
                    if (dbid == null)
                    {
                        db = (string)dbid;
                    }
                    else
                    {
                        db = dbid.ToString();
                    }

                    if (!string.IsNullOrEmpty(db))
                    {
                        string query2 = "delete from DeviceUserGroupDetail where deviceid = '" + db + "'";
                        cmd.CommandText = query2;
                        cmd.ExecuteNonQuery();

                        string query3 = "delete from configurationstore where deviceid ='" + db + "'";
                        cmd.CommandText = query3;
                        cmd.ExecuteNonQuery();

                        string query4 = "delete from DeviceWiseUser where deviceid ='" + db + "'";
                        cmd.CommandText = query4;
                        cmd.ExecuteNonQuery();

                        string query6 = "delete from DevicesInDeviceGroup where deviceid='" + db + "'";
                        cmd.CommandText = query6;
                        cmd.ExecuteNonQuery();
                        
                        string query5 = "delete from Device where dbid = '" + db + "'";
                        cmd.CommandText = query5;
                        cmd.ExecuteNonQuery();
                        Logger.Info("DATABASE: Device: " + deviceIp + " deleted successfully from db");
                    }
                    else
                    {
                        Logger.Info("DATABASE: Device: " + deviceIp + " doesn't exist in db");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "DATABASE: Failed to delete device from db");
                throw;
            }
        }

        #endregion Device related Db methods

        #region User related Db methods

        /// <summary>
        /// Method to get list of users from db
        /// </summary>
        /// <returns>List of users in EmployeeInfo</returns>
        public List<EmployeeInfo> GetUsersFromDb()
        {
            List<EmployeeInfo> userList = new List<EmployeeInfo>();
            DataTable dt = new DataTable();
            string query = "select [DbId], [FirstName],[LastName],[UserId],[IsSuspendedUser] from [User]";
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
                conn.Close();
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow userrow in dt.Rows)
                {
                    userList.Add(new EmployeeInfo()
                    {
                        EmployeeGuid = Guid.Parse(userrow["DbId"].ToString()),
                        EmployeeId = userrow["UserId"].ToString(),
                        IsEmployeeSuspended = Convert.ToBoolean(userrow["IsSuspendedUser"]),
                        EmployeeFirstName = userrow["FirstName"].ToString(),
                        EmployeeLastName = userrow["LastName"].ToString()
                    });
                }
            }
            else
            {
                Logger.Error("No user exist in db. Please create one for tests", "");
            }

            return userList;
        }

        /// <summary>
        /// Method to get array of userid from db
        /// </summary>
        /// <returns>array of UserId present in database</returns>
        public string[] GetUserIDsFromDb()
        {
            List<string> userIdList = new List<string>();

            string[] userIdArr;
            DataTable dt = new DataTable();
            string query = "select [UserId] from [User]";
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
                conn.Close();
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow userrow in dt.Rows)
                {
                    userIdList.Add(userrow["UserId"].ToString());
                }
            }
            else
            {
                Logger.Error("No user exist in db. Please create one for tests", "");
            }

            userIdArr = userIdList.ToArray();
            return userIdArr;
        }

        /// <summary>
        /// Verifies in Database that whether newly created user exists in databse or not
        /// </summary>
        /// <param name="users">Array of users present in database</param>
        /// <param name="createdUserId">newly created user</param>
        /// <returns></returns>
        public bool DoUserExsistsInDB(string[] users, string createdUserId)
        {
            bool result = false;

            try
            {
                result = users.Any(x => x.Equals(createdUserId));
                Logger.Info("Able to find created user in the database");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to find created user in the database");
                throw;
            }

            return result;
        }

        #endregion User related Db methods

        #region User Group Related Db methods

        public Dictionary<int, string> GetUserGroupsNameAndIdDictionary(List<string> ugNames)
        {
            //Dictionary<UserGroupsInfoModel, UserGroupsInfoModel> ugDictionary = new Dictionary<UserGroupsInfoModel, UserGroupsInfoModel>();
            Dictionary<int, string> ugDictionary = new Dictionary<int, string>();
            DataTable dt = new DataTable();

            foreach (var userGroupName in ugNames)
            {
                string query = "select [GroupId], [Name] from [UserGroup] where Name = " + "'" + userGroupName + "'";
                using (conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(dt);
                    conn.Close();
                }
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow userrow in dt.Rows)
                {
                    //ugDictionary.Add(new UserGroupsInfoModel()
                    //{
                    //    UserGroupID = Convert.ToInt32(userrow["GroupID"])
                    //}, new UserGroupsInfoModel()
                    //{
                    //    UserGroupName = userrow["Name"].ToString()
                    //});

                    ugDictionary.Add(Convert.ToInt32(userrow["GroupID"]), userrow["Name"].ToString());
                }
            }
            else
            {
                Logger.Error("No usergroup exist in db. Please create one for tests", "");
            }

            return ugDictionary;
        }

        #endregion User Group Related Db methods

        #region Application Log Db methods

        public ApplicationLogInfo GetApplicationLogFromDb()
        {
            DataTable dt = new DataTable();
            string query = "SELECT [DbId],[EvenTypeId],[IdentityField],[CreatedDateTime],[Description],[DeviceId],[Reason],[TransactionId] FROM [ApplicationEvent]";
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
                conn.Close();
            }
            int older1hourcount = 0, older1daycount = 0, older1weekcount = 0, older4weekscount = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                var older1hour = DateTime.Now.Subtract(TimeSpan.FromHours(1));
                var older1day = DateTime.Now.Subtract(TimeSpan.FromDays(1));
                var older1week = DateTime.Now.Subtract(TimeSpan.FromDays(7));
                var older4weeks = DateTime.Now.Subtract(TimeSpan.FromDays(28));
                //var query1 = from order in dt.AsEnumerable<> where order["CreatedDateTime"] > older1hour;
                var rows = dt.Rows.Cast<DataRow>();

                older1hourcount = rows.Where(row => Convert.ToDateTime(row["CreatedDateTime"]) < older1hour).Count();
                older1daycount = rows.Where(row => Convert.ToDateTime(row["CreatedDateTime"]) < older1day).Count();
                older1weekcount = rows.Where(row => Convert.ToDateTime(row["CreatedDateTime"]) < older1week).Count();
                older4weekscount = rows.Where(row => Convert.ToDateTime(row["CreatedDateTime"]) < older4weeks).Count();
            }
            else
            {
                Logger.Error("No user exist in db. Please create one for tests", "");
            }
            return new ApplicationLogInfo()
            {
                TotalCount = dt.Rows.Count,
                OlderthanPastHourLogCount = older1hourcount,
                OlderthanPastDayLogCount = older1daycount,
                OlderthanPastWeekLogCount = older1weekcount,
                Olderthan4PastWeekLogCount = older4weekscount
            };
        }

        #endregion Application Log Db methods

        #region Wiegand Db methods

        /// <summary>
        ///Method to get list of wiegands from db
        /// </summary>
        /// <returns>Array of wiegand in DB</returns>
        public string[] GetAllWiegandNames()
        {
            List<string> wiegandList = new List<string>();

            string[] wiegandNameArr;
            DataTable dt = new DataTable();
            string query = "select [Name] from [WiegandFormat]";
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
                conn.Close();
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow userrow in dt.Rows)
                {
                    wiegandList.Add(userrow["Name"].ToString());
                }
            }
            else
            {
                Logger.Error("No user exist in db. Please create one for tests", "");
            }
            wiegandNameArr = wiegandList.ToArray();
            return wiegandNameArr;
        }

        /// <summary>
        /// Verifies in Database that whether newly created wiegand name exists in databse or not
        /// </summary>
        /// <param name="wiegandNames">Array of wiegand names present in database</param>
        /// <param name="createdWiegandName">newly created wiegand name</param>
        /// <returns></returns>
        public bool DoWiegandExsistsInDB(string[] wiegandNames, string createdWiegandName)
        {
            bool result = false;

            try
            {
                result = wiegandNames.Any(x => x.Equals(createdWiegandName));
                Logger.Info("Able to find created wiegand name in the database");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to find created wiegand name in the database");
                throw;
            }

            return result;
        }

        #endregion Wiegand Db methods

        #region Device Groups related Db methods

        /// <summary>
        /// Method to get list of device group name
        /// </summary>
        /// <returns>Array of device groups present in DB</returns>
        public string[] GetAllDeviceGroupNames()
        {
            List<string> dgList = new List<string>();

            string[] dgNameArr;
            DataTable dt = new DataTable();
            string query = "select [Name] from [DeviceGroup]";
            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
                conn.Close();
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dgrow in dt.Rows)
                {
                    dgList.Add(dgrow["Name"].ToString());
                }
            }
            else
            {
                Logger.Error("No device group exist in db. Please create one for tests", "");
            }
            dgNameArr = dgList.ToArray();
            return dgNameArr;
        }

        /// <summary>
        /// Verifies in Database that whether newly created device group name exists in databse or not
        /// </summary>
        /// <param name="dgNames">Array of device groups names present in database</param>
        /// <param name="createdDgName">newly created device group name</param>
        /// <returns></returns>
        public bool DoDgExsistsInDB(string[] dgNames, string createdDgName)
        {
            bool result = false;

            try
            {
                result = dgNames.Any(x => x.Equals(createdDgName));
                Logger.Info("Able to find created device group name in the database");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to find created device group name in the database");
                throw;
            }

            return result;
        }

        /// <summary>
        /// Method to get all the usergroups present in device group
        /// </summary>
        /// <param name="dgName">Name of device group</param>
        /// <returns></returns>
        public List<string> GetUsergroupsInDevicegroup(string dgName)
        {
            List<string> usergroupList = new List<string>();
            DataTable dt = new DataTable();

            string query = "select ug.Name from [DeviceGroup] dg " +
                "inner join [DeviceUserGroupMapping] dug on dg.dbid = dug.DeviceGroupId " +
                "inner join [Usergroup] ug on dug.Usergroupid=ug.DbId where dg.Name= @param1";

            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@param1", dgName);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                conn.Close();
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow usergrouprow in dt.Rows)
                {
                    usergroupList.Add(usergrouprow["Name"].ToString());
                }
            }
            else
            {
                Logger.Error("No usergroup exist in devicegroup:" + dgName + "Please create one for tests", "");
            }

            return usergroupList;
        }

        /// <summary>
        /// Method to get all the devices present in device group
        /// </summary>
        /// <param name="dgName">Name of device group</param>
        /// <returns></returns>
        public List<string> GetDevicesInDevicegroup(string dgName)
        {
            List<string> deviceList = new List<string>();
            DataTable dt = new DataTable();

            string query = "select d.Name from [DeviceGroup] dg inner join [DeviceUserGroupDetail] dud on dg.dbid = dud.UserGroupId " +
                "inner join Device d on d.DbId = dud.deviceid" +
                " where dg.Name = @param1";

            using (conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@param1", dgName);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                conn.Close();
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow devicerow in dt.Rows)
                {
                    deviceList.Add(devicerow["Name"].ToString());
                }
            }
            else
            {
                Logger.Error("No device exist in devicegroup:" + dgName + "Please create one for tests", "");
            }

            return deviceList;
        }

        #endregion Device Groups related Db methods
    }
}