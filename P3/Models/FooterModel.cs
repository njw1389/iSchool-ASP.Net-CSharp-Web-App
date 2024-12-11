namespace P3.Models
{
    public class FooterModel
    {
        public Social social { get; set; }
        public List<QuickLink> quickLinks { get; set; }
        public Copyright copyright { get; set; }
        public string news { get; set; }
    }

    public class Copyright
    {
        public string title { get; set; }
        public string html { get; set; }
    }

    public class QuickLink
    {
        public string title { get; set; }
        public string href { get; set; }
    }

    public class Social
    {
        public string title { get; set; }
        public string tweet { get; set; }
        public string by { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
    }
}
