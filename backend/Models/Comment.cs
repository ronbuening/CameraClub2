using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string UserID { get; set; } = string.Empty;
        public User? User { get; set; }
        public int SubmissionID { get; set; }
        public Submission? Submission { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsAnonymous { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
