using System;
using System.Collections.Generic;
using TripsFinder.DAL.Models.Identity;

namespace TripsFinder.DAL.Models.Concrete
{
    public partial class Trip : BaseEntity
    {
        public Trip()
        {
            CheckPoints = new HashSet<CheckPoint>();
            Comments = new HashSet<Comment>();
            TripUsers = new HashSet<TripUser>();
            Users = new HashSet<User>();
        }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? PosterImageId { get; set; }
        public long StartingPointId { get; set; }
        public long? ArrivalPointId { get; set; }
        public long CreatedBy { get; set; }

        public MediaFile PosterImage { get; set; }
        public CheckPoint ArrivalPoint { get; set; }
        public User CreatedByUser { get; set; }
        public CheckPoint StartingPoint { get; set; }
        public ICollection<CheckPoint> CheckPoints { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<TripUser> TripUsers { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
