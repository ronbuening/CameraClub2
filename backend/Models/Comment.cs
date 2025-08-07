using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Comment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the comment.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who made the comment.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user who made the comment.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the submission the comment is associated with.
        /// </summary>
        public Guid SubmissionId { get; set; }

        /// <summary>
        /// Gets or sets the submission the comment is associated with.
        /// </summary>
        public Submission? Submission { get; set; }

        /// <summary>
        /// Gets or sets the text of the comment.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the comment is anonymous.
        /// </summary>
        public bool IsAnonymous { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the comment was made.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Initializes a new instance of the Comment class and sets default values.
        /// </summary>
        public Comment()
        {
            Id = Guid.NewGuid();
        }
    }
}
