namespace IXMWEBv2.Models
{
    public class PageItemsMetadataModel
    {
        public string PageCountString { get; set; }
        public int TotalItemsCount { get; set; }
        public int CurrentPageStartCount { get; set; }
        public int CurrentPageEndCount { get; set; }
        public string ModuleName { get; set; }
    }
}