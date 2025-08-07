using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid JudgeUserId { get; set; }
        public User? Judge { get; set; }
        public Guid SubmissionId { get; set; }
        public Submission? Submission { get; set; }
        public int Score { get; set; }
        public DateTime Timestamp { get; set; }

        public Rating()
        {
            Id = Guid.NewGuid();
        }
    }
}
