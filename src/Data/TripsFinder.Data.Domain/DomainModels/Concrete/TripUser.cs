using TripsFinder.Data.Domain.DomainModels.Identity;

namespace TripsFinder.Data.Domain.DomainModels.Concrete
{
    public partial class TripUser
    {
        public long TripId { get; set; }
        public long UserId { get; set; }

        public Trip Trip { get; set; }
        public User User { get; set; }
    }
}
