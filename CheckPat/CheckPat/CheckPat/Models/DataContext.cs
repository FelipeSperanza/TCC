using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace CheckPat.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //criando objeto do tipo builder que aponta para um arquivo Json que estará a configuração do banco de dados
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            // execução do builder
            var configuration = builder.Build();
            // o arquivo de configuração recebera uma string chamada default connection dentro do arquivo json
            optionsBuilder.UseMySql(configuration["ConnectionStrings:defaultConnection"]);
        }

        public DbSet<CheckPat.Models.Usuario> Usuario { get; set; }
        public DbSet<CheckPat.Models.Equipamento> Equipamento { get; set; }
        public DbSet<CheckPat.Models.Local> Local { get; set; }
        public DbSet<CheckPat.Models.Patrimonio> Patrimonio  { get; set; }
    }
}
