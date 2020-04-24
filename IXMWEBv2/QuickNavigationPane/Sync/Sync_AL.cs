using System;
using IXMWEBv2.Utils;

namespace IXMWEBv2.QuickNavigationPane.Sync
{
    public class Sync_AL
    {
        public Sync_PO syncPO;
        public static IXMWebUtils ixmUtils;

        public Sync_AL()
        {
            syncPO = new Sync_PO();
            ixmUtils = new IXMWebUtils();
        }

        /// <summary>
        /// Method creates sync group by adding employee group and device group to sync group and then clicking on "Sync" button
        /// </summary>
        /// <param name="EmployeeGrps">Names of employee groups</param>
        /// <param name="DeviceGrps">Names of device groups</param>
        /// <param name="SyncGrpName">Sync group name</param>
        public void CreateSyncGroup(string EmployeeGrps, string DeviceGrps, string SyncGrpName = null)
        {
            try
            {
                //Click on Add Sync Grp button
                syncPO.ClickAddSyncGrpBtn();

                // Add Employee group to sync group
                AddEmpGrpToSyncGrp(EmployeeGrps);

                //Add Device group to sync group
                AddDeviceGrpToSyncGrp(DeviceGrps);

                //Enter Sync Group Name
                syncPO.EnterSyncGrpName();

                //Save Sync Group
                syncPO.ClickSyncGrpSaveBtn();

                Logger.Info("Able to create sync group along with employee group and device group");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to create sync group along with employee group and device group");
                throw;
            }


        }

        /// <summary>
        /// Method to Add employee groups to sync group
        /// </summary>
        /// <param name="EmpGrpNames">Employee group names</param>
        public void AddEmpGrpToSyncGrp(string EmpGrpNames)
        {
            bool result = false;

            try
            {
                result = syncPO.SelectEmpGrp(EmpGrpNames);

                if (!result)
                {
                    syncPO.SearchAndAddEmpGrpToSyncGrp(EmpGrpNames);
                }

                Logger.Info("Able to add employee group to sync group successfully");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to add employee sync to device group");
                throw;
            }
        }

        /// <summary>
        /// Method to Add device groups to sync group
        /// </summary>
        /// <param name="DeviceGrpNames">Device group names</param>
        public void AddDeviceGrpToSyncGrp(string DeviceGrpNames)
        {
            bool result = false;

            try
            {
                result = syncPO.SelectDeviceGrp(DeviceGrpNames);

                if (!result)
                {
                    syncPO.SearchAndAddDeviceGrpToSyncGrp(DeviceGrpNames);
                }

                Logger.Info("Able to add device groups to sync group successfully");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to add device groups to sync group");
                throw;
            }
        }
    }
}