using MediatR;
using todo_api.Common;

namespace todo_api.Application.Queries.GetNoteList
{
    public class GetNoteListQuery : IRequest<List<Note>>
    {
        public List<String> TagList { get; set; }
    }
}
