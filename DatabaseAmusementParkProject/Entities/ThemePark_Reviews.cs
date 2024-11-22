namespace DatabaseAmusementParkProject.Entities
{
    public class ThemePark_Reviews
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public Guid ThemeParkLocationId { get; set; }
    }
}
