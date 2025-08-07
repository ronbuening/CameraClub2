using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class ClubMembership
    {
        public Guid Id { get; set; }
        public Guid ClubId { get; set; }
        public Club? Club { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string Role { get; set; } = "Member";

        public ClubMembership()
        {
            Id = Guid.NewGuid();
        }
    }
}
