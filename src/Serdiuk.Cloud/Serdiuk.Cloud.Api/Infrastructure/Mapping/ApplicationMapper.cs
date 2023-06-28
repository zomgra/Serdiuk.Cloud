using AutoMapper;
using Serdiuk.Cloud.Api.Data.Entity;
using Serdiuk.Cloud.Api.Models;


namespace Serdiuk.Cloud.Api.Infrastructure.Mapping
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<FileObject, FileViewModel>()
                .ForMember(x => x.Id, x => x.MapFrom(d => d.Id))
                .ForMember(x => x.Name, x => x.MapFrom(d => d.Name));
        }
    }
}
