using AutoMapper;

namespace todo_api.Application.Mapping.Common
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
