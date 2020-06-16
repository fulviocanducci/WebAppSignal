using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppSignal.Models
{
    [Table("todos")]
    public class Todo
    {
        [Key()]
        public int Id { get; set; }

        [Required()]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required()]
        public bool Done { get; set; }
    }

    public class DbaseContext: DbContext
    {
        public DbSet<Todo> Todo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ./db.db");
        }
    }
}
