using System.Collections.Generic;

namespace todo_api.Application.Queries.GetNoteList
{
    public class NoteListVM
    {
        public IList<NoteLookupDto> Notes { get; set; }
    }
}
