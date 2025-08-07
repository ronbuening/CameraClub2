using System;
using System.Collections.Generic;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Submission
    {
        public Guid Id { get; set; }
        public Guid CompetitionId { get; set; }
        public Competition? Competition { get; set; }
        public Guid ImageId { get; set; }
        public Image? Image { get; set; }
        public DateTime SubmissionTimestamp { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<Comment>? Comments { get; set; }

        public Submission()
        {
            Id = Guid.NewGuid();
            Ratings = new List<Rating>();
            Comments = new List<Comment>();
        }
    }
}
