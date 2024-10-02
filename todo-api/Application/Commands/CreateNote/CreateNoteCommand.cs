using MediatR;

namespace todo_api.Application.Commands
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public string Text { get; set; }
        public List<string> Tag { get; set; }
        public int Status { get; set; }
    }
}
