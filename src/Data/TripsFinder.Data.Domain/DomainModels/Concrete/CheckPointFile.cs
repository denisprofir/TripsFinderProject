﻿namespace TripsFinder.Data.Domain.DomainModels.Concrete
{
    public partial class CheckPointFile
    {
        public long CheckPointId { get; set; }
        public long MediaFileId { get; set; }

        public CheckPoint CheckPoint { get; set; }
        public MediaFile MediaFile { get; set; }
    }
}
