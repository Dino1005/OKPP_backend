using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace WebAPI.Controllers
{
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService commentService;

        public CommentController()
        {
            commentService = new CommentService();
        }

        [Authorize(Roles = "user, admin")]
        [Route("comments")]
        [HttpPost]
        public async Task<IActionResult> CreateCommentAsync(CommentREST comment)
        {
            var result = await commentService.CreateCommentAsync(new Comment(comment.EventId, comment.UserId, DateTime.Now, comment.Message));

            if (result)
            {
                return Ok(comment);
            }

            return BadRequest("Comment not created.");
        }

        [Authorize(Roles = "user, admin")]
        [Route("comments/{eventId}")]
        [HttpGet]
        public async Task<IActionResult> GetCommentsByEventIdAsync(string eventId)
        {
            var comments = await commentService.GetCommentsByEventIdAsync(eventId);

            if (comments != null)
            {
                return Ok(comments);
            }

            return BadRequest("Comments not found.");
        }
    }

    public class CommentREST
    {
        public string UserId { get; set; }
        public string EventId { get; set; }
        public string Message { get; set; }
    }
}