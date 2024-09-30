using MediatR;
using todo_api.Common;

namespace todo_api.Application.Queries.GetNote
{
    public class GetNoteQuery : IRequest<Note>
    {
        public Guid Id { get; set; }
    }
}
