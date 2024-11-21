using AutoMapper;

using StorageManager.Client.Contracts;

namespace StorageManager.Application.Mappers
{
    public class SiteMapperProfiles : Profile
    {
        public SiteMapperProfiles()
        {
            CreateMap<Domain.Entities.Site, Site>();
            CreateMap<Site, Domain.Entities.Site>();
        }
    }
}
