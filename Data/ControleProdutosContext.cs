using Microsoft.EntityFrameworkCore;
using ControleProdutos.Models;
namespace ControleProdutos.Data
{
    public class ControleProdutosContext : DbContext
    {

        public ControleProdutosContext(DbContextOptions<ControleProdutosContext> options): base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("conprod");
        }

        //Cria as tabelas nas migration e para usar nos conrollers 
        public DbSet<Produto> tbproduto { get; set; }
        public DbSet<Unidade> tbunidade { get; set; }
        public DbSet<LogErros> tblogerros { get; set; } 
        public DbSet<Cliente> tbcliente { get; set; }
        public DbSet<Venda> tbvenda { get; set; }


    }
}
