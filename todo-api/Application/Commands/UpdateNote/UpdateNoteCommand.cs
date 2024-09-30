using MediatR;

namespace todo_api.Application.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<string> Tag { get; set; }
        public int Status { get; set; }
    }
}
