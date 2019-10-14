
using AutoMapper;
using UserAdmin.Data.Entities;
using UserAdmin.ViewModels;

namespace UserAdmin.Data
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(u => u.UserId, ex => ex.MapFrom(u => u.Id))
                .ForMember(u => u.UserFirstName, ex => ex.MapFrom(u => u.FirstName))
                .ForMember(u => u.UserLastName, ex => ex.MapFrom(u => u.LastName))
                .ForMember(u => u.UserUserName, ex => ex.MapFrom(u => u.UserName))
                .ForMember(u => u.UserEmail, ex => ex.MapFrom(u => u.Email))
                .ForMember(u => u.UserActive, ex => ex.MapFrom(u => u.Active))
                .ReverseMap();
        }
    }
}
