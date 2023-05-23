using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener_DAL.Entities
{
    [Table("ShortUrl")]
    public class ShortUrlEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserEntity CreatedBy { get; set; }

    }
}
