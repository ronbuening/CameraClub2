using System;
using System.Collections.Generic;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid UploaderId { get; set; }
        public User? Uploader { get; set; }
        public string OriginalUrl { get; set; } = string.Empty;
        public DateTime UploadTimestamp { get; set; }
        public ICollection<Submission>? Submissions { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Rating>? Ratings { get; set; }

        public Image()
        {
            Id = Guid.NewGuid();
            Submissions = new List<Submission>();
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }
    }
}
