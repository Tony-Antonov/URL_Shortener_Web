using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener_DAL.Entities
{
    internal class UserEntity : IdentityUser<int>
    {
        public ICollection<ShortUrlEntity> Orders { get; set; }

    }
}
