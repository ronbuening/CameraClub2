using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Rating
    {
        /// <summary>
        /// Gets or sets the unique identifier for the rating.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the judge user.
        /// </summary>
        public Guid JudgeUserId { get; set; }

        /// <summary>
        /// Gets or sets the judge user associated with the rating.
        /// </summary>
        public User? Judge { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the submission.
        /// </summary>
        public Guid SubmissionId { get; set; }

        /// <summary>
        /// Gets or sets the submission associated with the rating.
        /// </summary>
        public Submission? Submission { get; set; }

        /// <summary>
        /// Gets or sets the score given by the judge.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the rating was given.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Initializes a new instance of the Rating class and sets default values.
        /// </summary>
        public Rating()
        {
            Id = Guid.NewGuid();
        }
    }
}
