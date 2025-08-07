using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class JudgingAssignment
    {
        public Guid Id { get; set; }
        public Guid CompetitionId { get; set; }
        public Competition? Competition { get; set; }
        public Guid JudgeUserId { get; set; }
        public User? Judge { get; set; }
        public string Status { get; set; } = "Assigned";
        public DateTime AssignedAt { get; set; }

        public JudgingAssignment()
        {
            Id = Guid.NewGuid();
        }
    }
}
