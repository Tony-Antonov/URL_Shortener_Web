using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace URL_Shortener_DAL.Context
{
    public class UrlShortenerContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>, IUrlShortenerContext
    {
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options): base(options) { }

        public DbSet<UserEntity> users { get; set; }
        public DbSet<ShortUrlEntity> shortUrls { get; set; }
    }
}
