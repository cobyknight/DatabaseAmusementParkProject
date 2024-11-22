namespace DatabaseAmusementParkProject.Entities
{
    public class User_Favorites
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ThemeParkId { get; set; }
    }
}
