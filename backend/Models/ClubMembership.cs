using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    /// <summary>
    /// Represents a membership within a club, linking a user to a club with a specific role.
    /// </summary>
    public class ClubMembership
    {
        /// <summary>
        /// Gets or sets the unique identifier for the membership.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the club.
        /// </summary>
        public Guid ClubId { get; set; }

        /// <summary>
        /// Gets or sets the club associated with this membership.
        /// </summary>
        public Club? Club { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user associated with this membership.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the role of the user within the club. Default is "Member".
        /// </summary>
        public string Role { get; set; } = "Member";

        /// <summary>
        /// Initializes a new instance of the ClubMembership class and sets default values.
        /// </summary>
        public ClubMembership()
        {
            Id = Guid.NewGuid();
        }
    }
}
