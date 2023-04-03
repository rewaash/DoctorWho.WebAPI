using AutoMapper;
using DoctorWho.Db.DataModels;
using DoctorWho.web.Models;

namespace DoctorWho.web.Profiles
{
    public class DoctorProfile:Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor,DoctorDto>();
        }
    }
}
