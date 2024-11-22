using Microsoft.EntityFrameworkCore;

namespace DatabaseAmusementParkProject.Entities
{
    public class ThemePark
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
