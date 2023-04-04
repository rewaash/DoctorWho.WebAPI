namespace DoctorWho.web.DTOs
{
    public class DoctorForUpsertDto
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
    }
}
