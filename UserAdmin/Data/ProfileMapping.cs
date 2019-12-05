using AutoMapper;
using UserAdmin.Data.Entities;
using UserAdmin.ViewModels;

namespace UserAdmin.Data
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<UserProfile, ProfileViewModel>()
                    .ForMember(p => p.ProfileProfileId, ex => ex.MapFrom(p => p.Id))
                    .ForMember(p => p.ProfileProfileDescription, ex => ex.MapFrom(p => p.ProfileDescription))
                    .ReverseMap();
        }
    }
}
