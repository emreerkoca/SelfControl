using Self.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self.Data.DataContext
{
    public class SelfContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Word> Word {get; set; }
        public DbSet<Sentence> Sentence { get; set; }
        public DbSet<Notification> Notification { get; set; }

    }
}
