using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener_BLL.Models
{
    public class ShortUrl
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Code { get; set; }
        public DateTime CreatedDate { get; set; }
        public User CreatedBy { get; set; }
    }
}
