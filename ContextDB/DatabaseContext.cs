using Microsoft.EntityFrameworkCore;
using projeto.Models;

namespace projeto.ContextDB
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Por os nomes das tabelas no singular
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Professor>().ToTable("Professor");
        }

        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }


    }
}
