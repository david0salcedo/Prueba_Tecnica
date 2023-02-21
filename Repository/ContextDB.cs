using Microsoft.EntityFrameworkCore;

namespace TEST.Repository
{
    public class ContextDB : DbContext
    {
        private readonly IConfiguration _configuration;

        public ContextDB(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public ContextDB(DbContextOptions options) : base(options)
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@_configuration.GetConnectionString("DefaultConnection"));        
        }

        public DbSet<Models.Cliente> Clientes { get; set; }
        public DbSet<Models.Persona> Personas { get; set; }
        public DbSet<Models.Cuenta> Cuentas { get; set; }
        public DbSet<Models.Movimiento> Movimientos { get; set; }


    }
}
