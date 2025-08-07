using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class JudgingAssignment
    {
        public int JudgingAssignmentID { get; set; }
        public int CompetitionID { get; set; }
        public Competition? Competition { get; set; }
        public string JudgeUserID { get; set; } = string.Empty;
        public User? Judge { get; set; }
        public string Status { get; set; } = "Assigned"; // Assigned, Completed
        public DateTime AssignedAt { get; set; }
    }
}
