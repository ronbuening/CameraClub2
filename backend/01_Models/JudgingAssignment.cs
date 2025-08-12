using System;
using CameraClub2.Models;

namespace CameraClub2.Models
{
    /// <summary>
    /// Represents an assignment of a judge to a competition for the purpose of judging entries.
    /// </summary>
    public class JudgingAssignment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the judging assignment.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the competition identifier that the judging assignment is associated with.
        /// </summary>
        public Guid CompetitionId { get; set; }

        /// <summary>
        /// Gets or sets the competition that is associated with the judging assignment.
        /// </summary>
        public Competition? Competition { get; set; }

        /// <summary>
        /// Gets or sets the user identifier for the judge assigned to the competition.
        /// </summary>
        public Guid JudgeUserId { get; set; }

        /// <summary>
        /// Gets or sets the judge that is assigned to the competition.
        /// </summary>
        public User? Judge { get; set; }

        /// <summary>
        /// Gets or sets the status of the judging assignment (e.g., Assigned, Completed).
        /// </summary>
        public string Status { get; set; } = "Assigned";

        /// <summary>
        /// Gets or sets the date and time when the judging assignment was assigned.
        /// </summary>
        public DateTime AssignedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the JudgingAssignment class and sets default values.
        /// </summary>
        public JudgingAssignment()
        {
            Id = Guid.NewGuid();
        }
    }
}
