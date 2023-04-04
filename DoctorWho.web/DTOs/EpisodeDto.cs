namespace DoctorWho.web.DTOs
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public string SeriesNumber { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
        public int DoctorId { get; set; }
        public string Notes { get; set; }
       
    }
}
