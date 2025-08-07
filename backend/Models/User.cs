using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class User : IdentityUser<Guid>
    {
        public string? DisplayName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }
        public new string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<ClubMembership>? ClubMemberships { get; set; }
        public ICollection<Equipment>? EquipmentList { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Image>? Uploads { get; set; }
        public ICollection<JudgingAssignment>? JudgingAssignments { get; set; }

        public User()
        {
            ClubMemberships = new List<ClubMembership>();
            EquipmentList = new List<Equipment>();
            Comments = new List<Comment>();
            Uploads = new List<Image>();
            JudgingAssignments = new List<JudgingAssignment>();
        }
    }
}
