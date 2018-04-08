using TripsFinder.DAL.Models.Identity;

namespace TripsFinder.DAL.Models.Concrete
{
    public partial class TripUser
    {
        public long TripId { get; set; }
        public long UserId { get; set; }

        public Trip Trip { get; set; }
        public User User { get; set; }
    }
}
