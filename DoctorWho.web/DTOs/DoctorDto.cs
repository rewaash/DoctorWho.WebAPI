using DoctorWho.Db.DataModels;

namespace DoctorWho.web.Models
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FirstEpisodeDate { get; set; }
        public DateTime LastEpisodeDate { get; set; }

    }
}
