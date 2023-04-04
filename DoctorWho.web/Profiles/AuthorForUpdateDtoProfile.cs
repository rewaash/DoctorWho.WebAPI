using AutoMapper;
using DoctorWho.Db.DataModels;
using DoctorWho.web.DTOs;

namespace DoctorWho.web.Profiles
{
    public class AuthorForUpdateDtoProfile:Profile
    {
        public AuthorForUpdateDtoProfile()
        {
            CreateMap<AuthorForUpdateDto, Author>();
        }
    }
}
