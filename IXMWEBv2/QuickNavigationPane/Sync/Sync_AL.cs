using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void CreateSyncGroup(string EmployeeGrp, string DeviceGrp)
        {
            syncPO.ClickAddSyncGrpBtn();

        }


        public void AddEmpGrpToSyncGrp(string EmpGrpName)
        {
            bool result = false;

//            result = 
        }
    }
}
