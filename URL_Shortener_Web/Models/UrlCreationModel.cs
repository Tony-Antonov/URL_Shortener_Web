using System.ComponentModel.DataAnnotations;

namespace URL_Shortener_Web.Models
{
    public class UrlCreationModel
    {
        [Required]
        public string Url { get; set; }
    }
}
