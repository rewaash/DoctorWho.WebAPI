using AutoMapper;
using DoctorWho.Db.DataModels;
using DoctorWho.web.DTOs;

namespace DoctorWho.web.Profiles
{
    public class EnemyDtoProfile :Profile
    {
        public EnemyDtoProfile()
        {
            CreateMap<EnemeyForCreationDto, Enemy>();
        }
    }
}
