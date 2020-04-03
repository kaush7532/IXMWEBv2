using IXMWEBv2.PageObjects;

namespace IXMWEBv2.AccessLayer
{
    public class HomeAccessLayer
    {
        public HomePage_PO home;

        public HomeAccessLayer()
        {
            home = new HomePage_PO();
        }

        public string GetIXMWebVersion()
        {
            home.TopBar.OpenAboutIXMWeb();
            return home.GetIXMWebVersion();
        }
    }
}