using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TripsFinder.Data.Domain.DomainModels.Concrete;

namespace TripsFinder.Data.Domain.DomainModels.Identity
{
    public class User : IdentityUser<long>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long? AvatarId { get; set; }
        public long? CurrentTripId { get; set; }

        public MediaFile Avatar { get; set; }
        public Trip CurrentTrip { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<TripUser> TripUsers { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
