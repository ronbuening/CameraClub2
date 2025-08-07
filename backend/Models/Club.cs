using System.Collections.Generic;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Club
    {
        public int ClubID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public ICollection<Competition>? Competitions { get; set; }
        public ICollection<ClubMembership>? Members { get; set; }
    }
}
