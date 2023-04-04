namespace DoctorWho.web.DTOs
{
    public class EpisodeForCreationDto
    {
        public string SeriesNumber { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
        public int DoctorId { get; set; }
        public string Notes { get; set; }
        
    }
}
