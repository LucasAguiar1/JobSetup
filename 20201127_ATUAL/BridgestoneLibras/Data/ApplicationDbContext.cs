using BridgestoneLibras.ModelsEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace BridgestoneLibras.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TB_PERIODOS> Periodo { get; set; }
        public DbSet<TB_RECURSOS> Recurso { get; set; }
        public DbSet<TB_LOGIN> Login { get; set; }
        //public DbSet<TB_SETOR> Setor { get; set; }
        //public DbSet<TB_MAQUINA> Maquina { get; set; }
        //public DbSet<TB_TRIPLEXB> Triplex { get; set; }


        public ApplicationDbContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_RECURSOS>()
                .HasKey(x => x.id );

            modelBuilder.Entity<TB_CC>()
                .ma(x => x.id);

            base.OnModelCreating(modelBuilder);

          
        }

        //.HasKey(x => new { x.ID });

        //If you name your foreign keys correctly, then you don't need this.
        /* modelBuilder.Entity<Recurso>()
             .HasOne(pt => pt.Funcao)
             .WithMany(p => p.Funcao_ID)
             .HasForeignKey(pt => pt.);

         modelBuilder.Entity<BookAuthor>()
             .HasOne(pt => pt.Author)
             .WithMany(t => t.BooksLink)
             .HasForeignKey(pt => pt.AuthorId); */
        //}
    }
}
