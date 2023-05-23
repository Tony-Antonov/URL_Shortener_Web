using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener_DAL.Entities
{
    [Table("User")]
    public class UserEntity : IdentityUser<int>
    {
        public ICollection<ShortUrlEntity> Orders { get; set; }

    }
}
