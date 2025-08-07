using System;
using System.Collections.Generic;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    public class Submission
    {
        public int SubmissionID { get; set; }
        public int CompetitionID { get; set; }
        public Competition? Competition { get; set; }
        public int ImageID { get; set; }
        public Image? Image { get; set; }
        public DateTime SubmissionTimestamp { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
