using Microsoft.EntityFrameworkCore;

namespace biblioteca
{
    public class BibliotecaDbContext : DbContext
    {

        
        public DbSet<Livro> Livros {get; set; }
        public DbSet<Editora> Editoras {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-E1HL06U;Initial Catalog=Biblioteca;Integrated Security=True;");

            
        }
    }
}