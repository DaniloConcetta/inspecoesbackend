using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Inspecoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Inspecoes.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<GrupoPerguntaPergunta> GrupoPerguntaPergunta { get; set; }
        public DbSet<GrupoPerguntaGrupoProduto> GrupoPerguntaGrupoProduto { get; set; }
        public DbSet<GrupoPergunta> GruposPerguntas { get; set; }
        public DbSet<GrupoProduto> GruposProdutos { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<TipoPergunta> TiposPerguntas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        /*  modelBuilder.Entity<GrupoPergunta>()
                .HasMany(c => c.Perguntas).WithMany(i => i.GruposPerguntas)
                .Map(t => t.MapLeftKey("GrupoPerguntaId")
                    .MapRightKey("PerguntaId")
                    .ToTable("GrupoPerguntaPergunta"));*/

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach (var relationship in 
                modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) 
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;

                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}