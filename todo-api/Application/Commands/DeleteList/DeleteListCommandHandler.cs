using MediatR;
using Microsoft.EntityFrameworkCore;
using todo_api.Common;
using todo_api.DB;

namespace todo_api.Application.Commands.DeleteList
{
    public class DeleteListCommandHandler
        : IRequestHandler<DeleteListCommand>
    {
        private readonly NotesDbContext _dbContext;

        public DeleteListCommandHandler(NotesDbContext dbContext) =>
            _dbContext = dbContext;


        public async Task Handle(DeleteListCommand request, CancellationToken cancellationToken)
        {
            foreach (var entity in _dbContext.Notes)
                _dbContext.Notes.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
