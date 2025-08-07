using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? Review { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Equipment()
        {
            Id = Guid.NewGuid();
        }
    }
}
