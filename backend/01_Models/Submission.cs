using System;
using System.Collections.Generic;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    /// <summary>
    /// Represents a submission made by a user for a competition, containing the submitted image, 
    /// submission time, and collections of ratings and comments.
    /// </summary>
    public class Submission
    {
        /// <summary>
        /// Gets or sets the unique identifier for the submission.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the competition identifier that the submission is associated with.
        /// </summary>
        public Guid CompetitionId { get; set; }

        /// <summary>
        /// Gets or sets the competition details for the associated competition identifier.
        /// </summary>
        public Competition? Competition { get; set; }

        /// <summary>
        /// Gets or sets the image identifier for the submitted image.
        /// </summary>
        public Guid ImageId { get; set; }

        /// <summary>
        /// Gets or sets the image details for the submitted image.
        /// </summary>
        public Image? Image { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of when the submission was made.
        /// </summary>
        public DateTime SubmissionTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the collection of ratings associated with the submission.
        /// </summary>
        public ICollection<Rating>? Ratings { get; set; }

        /// <summary>
        /// Gets or sets the collection of comments associated with the submission.
        /// </summary>
        public ICollection<Comment>? Comments { get; set; }

        /// <summary>
        /// Initializes a new instance of the Submission class and sets default values.
        /// </summary>
        public Submission()
        {
            Id = Guid.NewGuid();
            Ratings = new List<Rating>();
            Comments = new List<Comment>();
        }
    }
}
