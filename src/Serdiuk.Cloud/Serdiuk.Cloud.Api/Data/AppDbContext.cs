using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Cloud.Api.Data.Entity;
using Serdiuk.Cloud.Api.Data.IdentityModels;
using System.Reflection.Emit;

namespace Serdiuk.Cloud.Api.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<FileObject> Files { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FileObject>().HasQueryFilter(x => !x.IsRemove);

            builder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        }
    }
}
