using IXMSoft.Business.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXMWEBv2.Helper_SDK
{    
    public class TransactionLog_SDK: DeviceInfo_SDK
    {
        TransactionLogManager tlogmgr;

        public TransactionLog_SDK()
        {
            tlogmgr = new TransactionLogManager(nc);
        }

    }
}
