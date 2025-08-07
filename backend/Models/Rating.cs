using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public string JudgeUserID { get; set; } = string.Empty;
        public User? Judge { get; set; }
        public int SubmissionID { get; set; }
        public Submission? Submission { get; set; }
        public int Score { get; set; } // 1-10
        public DateTime Timestamp { get; set; }
    }
}
