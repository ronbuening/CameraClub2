using System;
using System.Collections.Generic;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Competition
    {
        /// <summary>
        /// Gets or sets the unique identifier for the competition.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the club identifier associated with the competition.
        /// </summary>
        public Guid ClubId { get; set; }

        /// <summary>
        /// Gets or sets the club associated with the competition.
        /// </summary>
        public Club? Club { get; set; }

        /// <summary>
        /// Gets or sets the title of the competition.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the theme of the competition.
        /// </summary>
        public string? Theme { get; set; }

        /// <summary>
        /// Gets or sets the description of the competition.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the upload limit for the competition.
        /// </summary>
        public int UploadLimit { get; set; }

        /// <summary>
        /// Gets or sets the start date and time for uploads.
        /// </summary>
        public DateTime UploadStart { get; set; }

        /// <summary>
        /// Gets or sets the end date and time for uploads.
        /// </summary>
        public DateTime UploadEnd { get; set; }

        /// <summary>
        /// Gets or sets the start date and time for judging.
        /// </summary>
        public DateTime JudgingStart { get; set; }

        /// <summary>
        /// Gets or sets the end date and time for judging.
        /// </summary>
        public DateTime JudgingEnd { get; set; }

        /// <summary>
        /// Gets or sets the start date and time for public access.
        /// </summary>
        public DateTime PublicStart { get; set; }

        /// <summary>
        /// Gets or sets the end date and time for public access.
        /// </summary>
        public DateTime PublicEnd { get; set; }

        /// <summary>
        /// Gets or sets the collection of submissions for the competition.
        /// </summary>
        public ICollection<Submission>? Submissions { get; set; }

        /// <summary>
        /// Gets or sets the collection of judging assignments for the competition.
        /// </summary>
        public ICollection<JudgingAssignment>? JudgingAssignments { get; set; }

        /// <summary>
        /// Initializes a new instance of the Competition class and sets default values.
        /// </summary>
        public Competition()
        {
            Id = Guid.NewGuid();
            Submissions = new List<Submission>();
            JudgingAssignments = new List<JudgingAssignment>();
        }
    }
}
