using Microsoft.EntityFrameworkCore;
using Db.Models;

namespace Db.Context
{
    public class TurPoengContext : DbContext
    {
        public TurPoengContext(DbContextOptions<TurPoengContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Pictures>().HasKey(x => new { x.PersonId, x.PostId });

            builder.Entity<IdrettslagPost>().HasKey(x => new { x.PostId, x.IdrettslagId });

            builder.Entity<IdrettslagMember>().HasKey(x => new { x.PersonId, x.IdrettslagId });

            builder.Entity<MyFriend>()
                .HasKey(x => new { x.PersonId, x.FriendId });

            builder.Entity<Person>()
                .HasMany(p => p.MyFriends)
                .WithOne(mf => mf.Person)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Badges> Badges { get; set; }
        public DbSet<Idrettslag> Idrettslag { get; set; }
        public DbSet<IdrettslagMember> IdrettslagMember { get; set; }
        public DbSet<IdrettslagPost> IdrettslagPost { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonActive> PersonActive { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostVisit> PostVisit { get; set; }
        public DbSet<MyFriend> MyFriend { get; set; }
    }
}
