using AutoMapper;
using DoctorWho.Db.DataModels;
using DoctorWho.web.DTOs;
using DoctorWho.web.Models;

namespace DoctorWho.web.Profiles
{
    public class DoctorForUpsertDtoProfile :Profile
    {
        public DoctorForUpsertDtoProfile()
        {
            CreateMap<DoctorForUpsertDto, Doctor>();
        }
    }
}
