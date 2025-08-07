using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class User : IdentityUser
    {
        public string? DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }
        public ICollection<ClubMembership>? ClubMemberships { get; set; }
        public ICollection<Equipment>? EquipmentList { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Image>? Uploads { get; set; }
        public ICollection<JudgingAssignment>? JudgingAssignments { get; set; }
    }
}
