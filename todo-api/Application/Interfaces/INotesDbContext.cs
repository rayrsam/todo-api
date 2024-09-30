using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using todo_api.Common;


namespace todo_api.Application.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
