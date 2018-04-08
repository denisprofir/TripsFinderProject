using System.Collections.Generic;
using TripsFinder.DAL.Models.Identity;

namespace TripsFinder.DAL.Models.Concrete
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
