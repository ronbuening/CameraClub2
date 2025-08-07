using Microsoft.AspNetCore.Mvc;
using CameraClub2.Models;
using CameraClub2.Interfaces;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JudgingAssignmentsController : ControllerBase
    {
        private readonly IJudgingAssignmentService _judgingAssignmentService;
        public JudgingAssignmentsController(IJudgingAssignmentService judgingAssignmentService)
        {
            _judgingAssignmentService = judgingAssignmentService;
        }

        /// <summary>
        /// Gets all judging assignments in the system.
        /// </summary>
        /// <returns>List of all judging assignments.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JudgingAssignment>>> GetJudgingAssignments()
        {
            var assignments = await _judgingAssignmentService.GetJudgingAssignmentsAsync();
            return Ok(assignments);
        }

        /// <summary>
        /// Adds a new judging assignment.
        /// </summary>
        /// <param name="assignment">JudgingAssignment object to add.</param>
        /// <returns>The created judging assignment.</returns>
        [HttpPost]
        public async Task<ActionResult<JudgingAssignment>> AddJudgingAssignment(JudgingAssignment assignment)
        {
            var added = await _judgingAssignmentService.AddJudgingAssignmentAsync(assignment);
            return CreatedAtAction(nameof(GetJudgingAssignments), new { id = added.Id }, added);
        }
    }
}
