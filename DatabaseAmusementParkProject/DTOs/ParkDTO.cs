using Microsoft.Extensions.Configuration.UserSecrets;

namespace DatabaseAmusementParkProject.DTOs
{
    public class ParkDTO
    {
        public string ParkName { get; set; }
        public string ParkLocation { get; set; }
        public Guid ParkId { get; set; }
        public Guid ParkLocationId { get; set; }
    }

    public class ReviewRequest
    {
        public Guid? Id { get; set; }
        public string Review { get; set; }
        public Guid UserId { get; set; }
        public int RatingScore { get; set; }
        public Guid ThemeParkId { get; set; }
        public Guid ThemeParkLocationId { get; set; }
    }
}
