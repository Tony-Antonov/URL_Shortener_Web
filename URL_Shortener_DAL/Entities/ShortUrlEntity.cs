using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener_DAL.Entities
{
    internal class ShortUrlEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ShortUrl { get; set; }
        public string ActualUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserEntity CreatedBy { get; set; }

    }
}
