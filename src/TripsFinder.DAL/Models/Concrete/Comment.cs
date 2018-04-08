﻿using System;
using TripsFinder.DAL.Models.Identity;

namespace TripsFinder.DAL.Models.Concrete
{
    public partial class Comment : BaseEntity
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public long Likes { get; set; }
        public long Dislikes { get; set; }
        public long TripId { get; set; }
        public long UserId { get; set; }
        public long? AnswerTo { get; set; }

        public Trip Trip { get; set; }
        public User User { get; set; }
    }
}
