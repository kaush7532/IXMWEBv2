using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXMWEBv2.QuickNavigationPane.Logs.ApplicationLogs
{


    public class ApplicationLogsLocators
    {
        public const string AppLogTile = ".//*[@title='Application Logs']";
        public const string AppLogTitle = "heading_title";
        public const string AppLogExportBtn = "export";
        public const string AppLogDeleteBtn = "DeleteAll";
        public const string AppLogColumnEdit = "columnedit";
        public const string AppLogSearchText = "searchText";
        public const string AppLogGridDivId = "ApplicationEvent";
        public const string ActionDropDownList = ".//*[@id='authenticate']//tr[1]/td[3]";
        public const string ActionKendoWindow = "TitleKendoWindow";
        public const string AppLogDataGrid = ".//*[@id='ApplicationEvent']/div[3]//td";

        /// <summary>
        /// ParamToDelete is dropdown list xpath where we can change path by [#num]
        /// </summary>
        public const string ParamToDelete = ".//*[@id='AppLogToDelete_listbox']/li[text()='#num']";

        public const string AppLogPassword = "PasswordBox";
        public const string DeletePopUPBtn = "OK";
        public const string KendoMsgBox = "KendoMsgBox_wnd_title";
        public const string MsgBoxText = ".//*[@id='KendoMsgBox']/div//p";
        public const string KendoMsgOKBtn = "msgBoxOkButton";
    }

    /// <summary>
    /// Params to delete application log from kendo dropdown.
    /// </summary>
    public class DeleteParamList
    {
        public const string KendoDropdownElementName = "AppLogToDelete";
        public const string SelectAll = "All";
        public const string OlderthanPastDay = "Older than past day";
        public const string OlderthanPastHour = "Older than past hour";
        public const string OlderthanPastWeek = "Older than past week";
        public const string Olderthan4PastWeek = "Older than past 4 weeks";
    }
}
