using Microsoft.EntityFrameworkCore;
using Self.Core.Entities;
using Self.Core.Interfaces;
using Self.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Self.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private IDomainEventDispatcher _dispatcher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IDomainEventDispatcher dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<Notification> Notification { get; set; }

        public override int SaveChanges()
        {
            int result = base.SaveChanges();

            //dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();

                foreach (var domainEvent in events)
                {
                    _dispatcher.Dispatch(domainEvent);
                }
            }


            return result;
        }
    }
}
