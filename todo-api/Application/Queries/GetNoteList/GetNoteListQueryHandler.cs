using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using todo_api.DB;
using Newtonsoft.Json;
using System.Diagnostics;
using todo_api.Common;

namespace todo_api.Application.Queries.GetNoteList
{
    public class GetNoteListQueryHandler
        : IRequestHandler<GetNoteListQuery, List<Note>>
    {
        private readonly NotesDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(NotesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<Note>> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            List<Note> notesQuery;

            if (request.TagList.Count == 0)
            {
                notesQuery = await _dbContext.Notes
                .ToListAsync();
            }
            else
            {
                notesQuery = await _dbContext.Notes
                .Where(note =>
                note.Tag.Intersect(request.TagList).Count() == request.TagList.Count())
                .ToListAsync();
            }
            return notesQuery;
        }
    }
}
