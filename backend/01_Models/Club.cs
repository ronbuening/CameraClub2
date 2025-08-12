using System;
using System.Collections.Generic;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Club
    {
        /// <summary>
        /// Gets or sets the unique identifier for the club.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the club.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the club.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the URL of the club's logo.
        /// </summary>
        public string? LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the competitions associated with the club.
        /// </summary>
        public ICollection<Competition>? Competitions { get; set; }

        /// <summary>
        /// Gets or sets the members of the club.
        /// </summary>
        public ICollection<ClubMembership>? Members { get; set; }

        /// <summary>
        /// Initializes a new instance of the Club class and sets default values.
        /// </summary>
        public Club()
        {
            Id = Guid.NewGuid();
            Competitions = new List<Competition>();
            Members = new List<ClubMembership>();
        }
    }
}
