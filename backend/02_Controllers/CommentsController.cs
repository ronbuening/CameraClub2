using Microsoft.AspNetCore.Mvc;
using CameraClub2.Models;
using CameraClub2.Interfaces;

namespace CameraClub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Gets all comments in the system.
        /// </summary>
        /// <returns>List of all comments.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            var comments = await _commentService.GetCommentsAsync();
            return Ok(comments);
        }

        /// <summary>
        /// Adds a new comment to a submission.
        /// </summary>
        /// <param name="comment">Comment object to add.</param>
        /// <returns>The created comment.</returns>
        [HttpPost]
        public async Task<ActionResult<Comment>> AddComment(Comment comment)
        {
            var added = await _commentService.AddCommentAsync(comment);
            return CreatedAtAction(nameof(GetComments), new { id = added.Id }, added);
        }
    }
}
