using MediatR;
using Microsoft.EntityFrameworkCore;
using todo_api.Application.Interfaces;
using todo_api.Common;

namespace todo_api.Application.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler
        : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _dbContext;

        public UpdateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Notes.FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Text = request.Text;
            entity.Tag = request.Tag;
            entity.Status = request.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
