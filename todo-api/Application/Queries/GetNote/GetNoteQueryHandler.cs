using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using todo_api.Application.Interfaces;
using todo_api.Common;

namespace todo_api.Application.Queries.GetNote
{
    public class GetNoteQueryHandler
        : IRequestHandler<GetNoteQuery, Note>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNoteQueryHandler(INotesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Note> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FirstOrDefaultAsync(note =>
                note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            return entity;
        }
    }
}
