using MediatR;
using todo_api.Application.Commands.CreateNote;

namespace todo_api.Application.Commands.CreateList
{
    public class CreateListCommand : IRequest
    {
        public List<CreateNoteCommand> notes { get; set; }
    }

}
