using MediatR;
using todo_api.Application.Interfaces;

namespace todo_api.Application.Commands.CreateList
{
    public class CreateListCommandHandler
        : IRequestHandler<CreateListCommand>
    {

        private readonly INotesDbContext _dbContext;

        public CreateListCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Handle(CreateListCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
