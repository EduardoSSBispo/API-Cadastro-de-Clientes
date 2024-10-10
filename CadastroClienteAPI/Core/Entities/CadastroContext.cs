using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.Entities
{
    public class CadastroContext : DbContext
    {
        private IConfiguration _configuration;

        public CadastroContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public CadastroContext()
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }

        public virtual DbSet<Logradouro> Logradouro { get; set; }

        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var typeDatabase = _configuration["TypeDatabase"];
            var connectionString = _configuration.GetConnectionString(typeDatabase);

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
