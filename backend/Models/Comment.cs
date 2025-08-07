using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid SubmissionId { get; set; }
        public Submission? Submission { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsAnonymous { get; set; }
        public DateTime Timestamp { get; set; }

        public Comment()
        {
            Id = Guid.NewGuid();
        }
    }
}
