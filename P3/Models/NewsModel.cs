namespace P3.Models
{
    public class NewsModel
    {
        public List<Older> older { get; set; }
    }

    public class Older
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
