using MediatR;
using Microsoft.EntityFrameworkCore;
using todo_api.Common;
using todo_api.DB;

namespace todo_api.Application.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler
        : IRequestHandler<DeleteNoteCommand>
    {
        private readonly NotesDbContext _dbContext;

        public DeleteNoteCommandHandler(NotesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            _dbContext.Notes.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
