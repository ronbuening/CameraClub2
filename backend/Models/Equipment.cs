using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Equipment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the equipment.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the equipment.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the rating of the equipment.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the review for the equipment.
        /// </summary>
        public string? Review { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who owns the equipment.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user who owns the equipment.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Initializes a new instance of the Equipment class and sets default values.
        /// </summary>
        public Equipment()
        {
            Id = Guid.NewGuid();
        }
    }
}
