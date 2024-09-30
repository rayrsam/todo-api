using MediatR;

namespace todo_api.Application.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
