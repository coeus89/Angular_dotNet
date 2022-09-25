using AutoMapper;

namespace StudentAdminPortal.API.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<DataModels.Student, DomainModels.Student>()
                .ReverseMap();

            CreateMap<DataModels.Gender, DomainModels.Gender>()
                .ReverseMap();

            CreateMap<DataModels.Address, DomainModels.Address>()
                .ReverseMap();
        }
    }
}
