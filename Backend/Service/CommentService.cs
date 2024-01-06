using Model;
using Repository;

namespace Service
{
    public class CommentService
    {
        private readonly CommentRepository repository;
        public CommentService()
        {
            repository = new CommentRepository();
        }

        public async Task<List<Comment>> GetCommentsByEventIdAsync(string eventId)
        {
            var commentDictionaries = await repository.GetAllCommentsAsync();

            var comments = new List<Comment>();

            foreach (var commentDictionary in commentDictionaries)
            {
                comments.Add(Comment.MapDictionaryToComment(commentDictionary));
            }

            return comments.Where(a => a.EventId == eventId).ToList();
        }


        public async Task<bool> CreateCommentAsync(Comment comment)
        {
            return await repository.CreateCommentAsync(comment);
        }
    }
}