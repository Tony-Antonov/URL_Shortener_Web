﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener_DAL.Entities;

namespace URL_Shortener_DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IShortUrlRepository ShortUrls { get; }
        Task Save();
    }
}
