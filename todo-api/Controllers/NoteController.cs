using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using todo_api.Application.Commands.DeleteList;
using todo_api.Application.Commands.DeleteNote;
using todo_api.Application.Commands.UpdateNote;
using todo_api.Application.Queries.GetNote;
using todo_api.Application.Queries.GetNoteList;
using todo_api.Common;
using todo_api.Application.Commands;

namespace todo_api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class NoteController : BaseController
    {
        private readonly IMapper _mapper;
        public NoteController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet("{tagString}")]
        public async Task<ActionResult<List<Note>>> GetList(String tagString)
        {
            var tag = tagString.Split("_");


            var query = new GetNoteListQuery
            {
                TagList = tag.ToList()
            };
            var JsonResult = await Mediator.Send(query);
            return Ok(JsonResult);
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetList()
        {
            var query = new GetNoteListQuery
            {
                TagList = []
            };
            var JsonResult = await Mediator.Send(query);
            return Ok(JsonResult);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteVM>> Get(Guid id)
        {
            var query = new GetNoteQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteCommand command)
        {
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNoteCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteList()
        {
            var delCommand = new DeleteListCommand
            {
               
            };
            await Mediator.Send(delCommand);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateList([FromBody] List<Note> notes)
        {

            await DeleteList();


            foreach(var note in notes)
            {
                var command = new CreateNoteCommand
                {
                    Id = note.Id,
                    Text = note.Text,
                    Tag = note.Tag,
                    Status = note.Status,
                };
                await Mediator.Send(command);
            }

            return NoContent();
        }

    }
}
