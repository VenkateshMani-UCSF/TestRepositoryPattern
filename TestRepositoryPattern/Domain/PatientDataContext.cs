using Microsoft.EntityFrameworkCore;
using TestRepositoryPattern.Models;

namespace TestRepositoryPattern.Domain
{
     public class PatientDataContext : DbContext
     {
          public PatientDataContext() : base()
          {
          }

          public PatientDataContext(DbContextOptions dbContextOptions)
               : base(dbContextOptions)
          {
          }

          public DbSet<CodeVerifier> CodeVerifiers { get; set; }
          public DbSet<ReferralState> ReferralStates { get; set; }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               optionsBuilder.UseSqlServer("Server=VENKATESH\\SQLEXPRESS; Database=PatientApp; User Id=sa; password=Venky@5810");
               base.OnConfiguring(optionsBuilder);
          }
     }
}
