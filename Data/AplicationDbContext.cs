using Microsoft.EntityFrameworkCore;
namespace Mia_Tecno_Store_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Forros> Forros { get; set; }
        public DbSet<Models.Archivo> Archivo { get; set; }

    }
}
