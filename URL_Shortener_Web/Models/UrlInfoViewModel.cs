using URL_Shortener_BLL.Models;

namespace URL_Shortener_Web.Models
{
    public class UrlInfoViewModel
    {
        public string Url { get; set; }
        public string ShortedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
