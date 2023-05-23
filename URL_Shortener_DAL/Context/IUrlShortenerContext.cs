using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_DAL.Entities;

namespace URL_Shortener_DAL.Context
{
    public interface IUrlShortenerContext
    {
        public DbSet<UserEntity> users { get; set; }
        public DbSet<ShortUrlEntity> shortUrls { get; set; }
    }
}
