using Microsoft.EntityFrameworkCore;
using Petzey.Pet.Model;

namespace Petzey.Pet.Repository.DataAccessLayer
{
    public class PetDbContext : DbContext
    {
        public PetDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<PetOwner> PetOwner { get; set; }
        public DbSet<PetProfile> PetProfile { get; set; }
        public DbSet<User> User { get; set; }
    }
}