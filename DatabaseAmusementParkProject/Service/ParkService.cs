using DatabaseAmusementParkProject.Data;
using DatabaseAmusementParkProject.DTOs;
using DatabaseAmusementParkProject.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Reflection.Metadata.Ecma335;

namespace DatabaseAmusementParkProject.Service
{
    public class ParkService
    {
        private readonly AppDbContext _context;
        public ParkService(AppDbContext context)
        {
            _context = context;
        }

/*        public List<ParkDTO> GetAllParks()
        {

            var parks = _context.ThemeParks
                .Select(tp => new
                {
                    tp.Name
                }).ToList();

            List<ParkDTO> parksWithLocation = new List<ParkDTO>();

            var locations = _context.Locations.ToDictionary(l => l.id, l => l.name);

            foreach (var park in parks)
            {
                parksWithLocation.Add(new ParkDTO
                {
                    ParkName = park.Name,
                    ParkLocation = locations.ContainsKey(park.LocationId) ? locations[park.LocationId] : null
                });
            }

            return parksWithLocation;

        }*/

        public List<Location> GetAllLocations()
        {
            var locations = _context.Locations.ToList();

            return locations;
        }

        public List<ParkDTO> GetParksByLocation(Guid locationId)
        {
            var parks = _context.ThemeParks.Select(tp => new ParkDTO
            {
                ParkName = tp.Name,
                ParkLocation = _context.Locations
                    .Where(l => l.id == locationId)
                    .Select(l => l.name).FirstOrDefault()
            }).ToList();

            return parks;
        }

        public bool LeaveparkReview(string review, int ratingScore, Guid themeParkId)
        {
            if (string.IsNullOrWhiteSpace(review) || ratingScore < 1 || ratingScore > 5)
            {
                return false;
            }

            var newReview = new ThemePark_Reviews
            {
                Id = Guid.NewGuid(),
                Comment = review,
                Rating = ratingScore,
                ThemeParkLocationId = themeParkId
            };

            _context.ThemeParks_Review.Add(newReview);

            int changes = _context.SaveChanges();

            return changes > 0;
        }

/*        public List<ThemePark_Reviews> GetThemeParkReviews(Guid parkId)
        {
            var reviews = _context.ThemeParks_Review.Where(tpr => tpr.ThemeLocationId == parkId).ToList();
            return reviews;
        }*/

        public bool DeleteReview(Guid reviewId)
        {
            var review = _context.ThemeParks_Review.SingleOrDefault(_ => _.Id == reviewId);

            if (review == null)
            {
                return false;
            }

            _context.ThemeParks_Review.Remove(review);

            int changes = _context.SaveChanges();


            return changes > 0;
        }
    }
}
