using System;
using System.Collections.Generic;

namespace TripsFinder.Data.Domain.DomainModels.Concrete
{
    public class CheckPoint : BaseEntity
    {
        public CheckPoint()
        {
            CheckPointsFiles = new HashSet<CheckPointFile>();
        }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long TripId { get; set; }

        public Trip Trip { get; set; }
        public ICollection<Trip> TripsArrivalPoint { get; set; }
        public Trip TripStartingPoint { get; set; }
        public ICollection<CheckPointFile> CheckPointsFiles { get; set; }
    }
}
