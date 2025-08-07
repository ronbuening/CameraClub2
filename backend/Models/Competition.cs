using System;
using System.Collections.Generic;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Competition
    {
        public Guid Id { get; set; }
        public Guid ClubId { get; set; }
        public Club? Club { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Theme { get; set; }
        public string? Description { get; set; }
        public int UploadLimit { get; set; }
        public DateTime UploadStart { get; set; }
        public DateTime UploadEnd { get; set; }
        public DateTime JudgingStart { get; set; }
        public DateTime JudgingEnd { get; set; }
        public DateTime PublicStart { get; set; }
        public DateTime PublicEnd { get; set; }
        public ICollection<Submission>? Submissions { get; set; }
        public ICollection<JudgingAssignment>? JudgingAssignments { get; set; }

        public Competition()
        {
            Id = Guid.NewGuid();
            Submissions = new List<Submission>();
            JudgingAssignments = new List<JudgingAssignment>();
        }
    }
}
