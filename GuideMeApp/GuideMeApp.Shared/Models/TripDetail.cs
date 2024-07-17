﻿#nullable disable

using System.ComponentModel.DataAnnotations;

namespace GuideMeApp.Shared.Models
{
    public class TripDetail : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int TripId { get; set; }
        public Trip Trip { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
    }
}
