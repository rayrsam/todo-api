using AutoMapper;
using todo_api.Application.Mapping.Common;
using todo_api.Common;

namespace todo_api.Application.Queries.GetNote
{
    public class NoteVM : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Tag { get; set; }
        public int Status { get; set; }

        public void Mappping(Profile profile)
        {
            profile.CreateMap<Note, NoteVM>()
                .ForMember(noteVM => noteVM.Text,
                    opt => opt.MapFrom(note => note.Text))
                .ForMember(noteVM => noteVM.Tag,
                    opt => opt.MapFrom(note => note.Tag))
                .ForMember(noteVM => noteVM.Status,
                    opt => opt.MapFrom(note => note.Status));
        }
    }
}