using AutoMapper;
using DoctorWho.Db.DataModels;
using DoctorWho.web.DTOs;

namespace DoctorWho.web.Profiles
{
    public class CompanionForCreationDtoProfile :Profile
    {
        public CompanionForCreationDtoProfile()
        {
            CreateMap<CompanionForCreationDto, Companion>();
        }
    }
}
