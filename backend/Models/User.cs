using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class User : IdentityUser<Guid>
    {
        /// <summary>
        /// Gets or sets the display name of the user.
        /// </summary>
        public string? DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the avatar URL of the user.
        /// </summary>
        public string? AvatarUrl { get; set; }

        /// <summary>
        /// Gets or sets the bio of the user.
        /// </summary>
        public string? Bio { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public new string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the club memberships associated with the user.
        /// </summary>
        public ICollection<ClubMembership>? ClubMemberships { get; set; }

        /// <summary>
        /// Gets or sets the equipment list associated with the user.
        /// </summary>
        public ICollection<Equipment>? EquipmentList { get; set; }

        /// <summary>
        /// Gets or sets the comments made by the user.
        /// </summary>
        public ICollection<Comment>? Comments { get; set; }

        /// <summary>
        /// Gets or sets the images uploaded by the user.
        /// </summary>
        public ICollection<Image>? Uploads { get; set; }

        /// <summary>
        /// Gets or sets the judging assignments associated with the user.
        /// </summary>
        public ICollection<JudgingAssignment>? JudgingAssignments { get; set; }

        /// <summary>
        /// Initializes a new instance of the User class and sets default values for collections.
        /// </summary>
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
