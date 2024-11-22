namespace DatabaseAmusementParkProject.Entities
{
    public class ThemePark_Location
    {
        public Guid Id { get; set; }
        public Guid ThemeParkId { get; set; }
        public Guid LocationId { get; set; }
    }
}
