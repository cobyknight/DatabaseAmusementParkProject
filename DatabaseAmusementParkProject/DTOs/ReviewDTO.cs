public class ReviewDTO
{
    public Guid ReviewId { get; set; }
    public Guid UserId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public Guid ThemeParkId { get; set; }
    public Guid ThemeParkLocationId { get; set; }
    public string ThemeParkName { get; set; }
}