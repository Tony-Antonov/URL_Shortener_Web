namespace URL_Shortener_BLL.Models
{
    public class ShortUrl
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Code { get; set; }
        public string ShortedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public User CreatedBy { get; set; }
    }
}
