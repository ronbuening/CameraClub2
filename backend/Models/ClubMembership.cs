using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class ClubMembership
    {
        public int ClubMembershipID { get; set; }
        public int ClubID { get; set; }
        public Club? Club { get; set; }
        public string UserID { get; set; } = string.Empty;
        public User? User { get; set; }
        public string Role { get; set; } = "Member"; // Member, Judge, ClubAdmin
    }
}
