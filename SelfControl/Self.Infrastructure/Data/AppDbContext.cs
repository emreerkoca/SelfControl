﻿using Microsoft.EntityFrameworkCore;
using Self.Core.Entities;
using Self.Core.Entities.BasketAggregate;
using Self.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Self.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<Notification> Notification { get; set; }
    }
}
