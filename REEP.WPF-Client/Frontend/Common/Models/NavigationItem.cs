namespace REEP.WPF_Client.Frontend.Common.Models
{
    public class NavigationItem
    {
        public string Title { get; set; } = string.Empty;
        public string PageName { get; set; } = string.Empty;

        public NavigationItem(string title, string pageName)
        {
            Title = title;
            PageName = pageName;
        }
    }
}
