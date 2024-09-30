using AutoMapper;
using todo_api.Application.Mapping.Common;
using todo_api.Common;

namespace todo_api.Application.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Tag { get; set; }
        public int Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Text,
                    opt => opt.MapFrom(note => note.Text))
                 .ForMember(noteDto => noteDto.Tag,
                    opt => opt.MapFrom(note => note.Tag))
                .ForMember(noteDto => noteDto.Status,
                    opt => opt.MapFrom(note => note.Status));
        }
    }
}
