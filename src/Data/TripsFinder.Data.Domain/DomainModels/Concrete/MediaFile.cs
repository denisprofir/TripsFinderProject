using System.Collections.Generic;
using TripsFinder.Data.Domain.DomainModels.Identity;

namespace TripsFinder.Data.Domain.DomainModels.Concrete
{
    public partial class MediaFile : BaseEntity
    {
        public MediaFile()
        {
            CheckPointsFiles = new HashSet<CheckPointFile>();
            Users = new HashSet<User>();
        }
        
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }

        public ICollection<CheckPointFile> CheckPointsFiles { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
