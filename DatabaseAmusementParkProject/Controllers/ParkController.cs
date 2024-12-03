using DatabaseAmusementParkProject.DTOs;
using DatabaseAmusementParkProject.Entities;
using Microsoft.AspNetCore.Mvc;
using DatabaseAmusementParkProject.Data;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAmusementParkProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParkController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Park/parks
        [HttpGet("parks")]
        public IActionResult GetAllParks()
        {
            var parks = _context.ThemeParks_Locations.ToList();

            var allParks = new List<ParkDTO>();

            foreach (var park in parks)
            {
                var parkName = _context.ThemeParks
                    .Where(tp => tp.Id == park.ThemeParkId)
                    .Select(tp => tp.Name)
                    .FirstOrDefault();

                var locationName = _context.Locations
                    .Where(l => l.id == park.LocationId)
                    .Select(l => l.name)
                    .FirstOrDefault();

                allParks.Add(new ParkDTO
                {
                    ParkName = parkName,
                    ParkLocation = locationName,
                    ParkId = park.ThemeParkId,
                    ParkLocationId = park.Id // Use the Id from ThemePark_Location
                });
            }

            return Ok(allParks);
        }

        // GET: api/Park/locations
        [HttpGet("locations")]
        public IActionResult GetAllLocations()
        {
            var locations = _context.Locations.ToList();
            return Ok(locations);
        }

        // GET: api/Park/parks/location/{locationId}
        [HttpGet("parks/location/{locationId}")]
        public IActionResult GetParksByLocation(Guid locationId)
        {
            var parkLocations = _context.ThemeParks_Locations
                .Where(tpl => tpl.LocationId == locationId)
                .ToList();

            var parks = new List<ParkDTO>();

            foreach (var tpl in parkLocations)
            {
                var themePark = _context.ThemeParks.FirstOrDefault(tp => tp.Id == tpl.ThemeParkId);
                var location = _context.Locations.FirstOrDefault(l => l.id == tpl.LocationId);

                if (themePark != null && location != null)
                {
                    parks.Add(new ParkDTO
                    {
                        ParkId = tpl.ThemeParkId,
                        ParkName = themePark.Name,
                        ParkLocation = location.name,
                        ParkLocationId = tpl.Id // Use the Id from ThemePark_Location
                    });
                }
            }

            return Ok(parks);
        }

        // POST: api/Park/review
        [HttpPost("review")]
        public IActionResult LeaveParkReview([FromBody] ReviewRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Review) || request.RatingScore < 1 || request.RatingScore > 5)
            {
                return BadRequest("Invalid input data.");
            }

            // Validate that User exists
            var userExists = _context.Users.Any(u => u.Id == request.UserId);
            if (!userExists)
            {
                return BadRequest("User does not exist.");
            }

            // Validate that ThemeParkLocation exists
            var tplExists = _context.ThemeParks_Locations.Any(tpl => tpl.Id == request.ThemeParkLocationId);
            if (!tplExists)
            {
                return BadRequest("Theme Park Location does not exist.");
            }

            var newReview = new ThemePark_Reviews
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Comment = request.Review,
                Rating = request.RatingScore,
                ThemeParkLocationId = request.ThemeParkLocationId
            };

            _context.ThemeParks_Review.Add(newReview);
            int changes = _context.SaveChanges();

            if (changes > 0)
            {
                return Ok("Review successfully added.");
            }

            return StatusCode(500, "Error adding the review.");
        }

        // GET: api/Park/reviews/{parkLocationId}
        [HttpGet("reviews/{parkLocationId}")]
        public IActionResult GetThemeParkReviews(Guid parkLocationId)
        {
            var reviews = _context.ThemeParks_Review
                .Where(tpr => tpr.ThemeParkLocationId == parkLocationId)
                .ToList();
            return Ok(reviews);
        }

        // DELETE: api/Park/review/{reviewId}
        [HttpDelete("review/{reviewId}")]
        public IActionResult DeleteReview(Guid reviewId)
        {
            var review = _context.ThemeParks_Review.SingleOrDefault(r => r.Id == reviewId);

            if (review == null)
            {
                return NotFound("Review not found.");
            }

            _context.ThemeParks_Review.Remove(review);
            int changes = _context.SaveChanges();

            if (changes > 0)
            {
                return Ok("Review successfully deleted.");
            }

            return StatusCode(500, "Error deleting the review.");
        }

        // PUT: api/Park/review
        [HttpPut("review")]
        public IActionResult UpdateReview([FromBody] ReviewRequest request)
        {
            if (request.Id == null)
            {
                return BadRequest("Review ID is required.");
            }

            // Find the review in the database
            var review = _context.ThemeParks_Review.FirstOrDefault(tpr => tpr.Id == request.Id);

            // Check if the review exists
            if (review == null)
            {
                return NotFound("Review not found");
            }

            // Update the review's fields
            review.Rating = request.RatingScore;
            review.Comment = request.Review;

            // Save changes to the database
            try
            {
                _context.SaveChanges();
                return Ok("Review updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetParksBySearch")]
        public IActionResult SearchParks(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest("Search term cannot be empty.");
            }

            // Perform a case-insensitive search
            var matchingParks = _context.ThemeParks
                .Where(tp => EF.Functions.Like(tp.Name, $"%{searchTerm}%"))
                .ToList();

            if (!matchingParks.Any())
            {
                return NotFound("No parks found matching the search term.");
            }

            var result = new List<ParkDTO>();

            foreach (var park in matchingParks)
            {
                var locations = _context.ThemeParks_Locations
                    .Where(tpl => tpl.ThemeParkId == park.Id)
                    .ToList();

                foreach (var location in locations)
                {
                    var locationName = _context.Locations
                        .Where(l => l.id == location.LocationId)
                        .Select(l => l.name)
                        .FirstOrDefault();

                    result.Add(new ParkDTO
                    {
                        ParkName = park.Name,
                        ParkLocation = locationName,
                        ParkId = park.Id,
                        ParkLocationId = location.Id
                    });
                }
            }

            return Ok(result);
        }
    }
}
