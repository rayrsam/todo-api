using Microsoft.EntityFrameworkCore;
using todo_api.Application.Interfaces;
using todo_api.Common;
using todo_api.DB.config;

namespace todo_api.DB
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfig());

            modelBuilder.Entity<Note>().HasData
                (
                   
                ); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
