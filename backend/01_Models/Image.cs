using System;
using System.Collections.Generic;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Image
    {
        /// <summary>
        /// Gets or sets the unique identifier for the image.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who uploaded the image.
        /// </summary>
        public Guid UploaderId { get; set; }

        /// <summary>
        /// Gets or sets the user who uploaded the image.
        /// </summary>
        public User? Uploader { get; set; }

        /// <summary>
        /// Gets or sets the original URL of the image.
        /// </summary>
        public string OriginalUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the timestamp when the image was uploaded.
        /// </summary>
        public DateTime UploadTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the collection of submissions for the image.
        /// </summary>
        public ICollection<Submission>? Submissions { get; set; }

        /// <summary>
        /// Gets or sets the collection of comments on the image.
        /// </summary>
        public ICollection<Comment>? Comments { get; set; }

        /// <summary>
        /// Gets or sets the collection of ratings for the image.
        /// </summary>
        public ICollection<Rating>? Ratings { get; set; }

        /// <summary>
        /// Initializes a new instance of the Image class and sets default values.
        /// </summary>
        public Image()
        {
            Id = Guid.NewGuid();
            Submissions = new List<Submission>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }
    }
}
