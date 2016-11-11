using AutoMapper;
using Libsys.Domain.Model;
using Libsys.WebApi.Dtos;

namespace Libsys.WebApi.AutoMapper.Configurations
{
    public class BookMapperConfiguration : Profile
    {
        protected override void Configure()
        {
            CreateMap<Book, BookDto4R>()
                .ForMember(b => b.PublisherName, p => p.MapFrom(b => b.Publisher == null ? string.Empty : b.Publisher.Name));
        }
    }
}