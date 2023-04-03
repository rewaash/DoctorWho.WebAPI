using AutoMapper;
using DoctorWho.Db.DataModels;
using DoctorWho.web.DTOs;

namespace DoctorWho.web.Profiles
{
    public class EpisodeProfile :Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Episode, EpisodeDto>();
        }
    }
}
