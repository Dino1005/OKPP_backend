using Google.Cloud.Firestore;
using Model;

namespace Repository
{
    public class CommentRepository
    {
        private readonly Database database;

        public CommentRepository()
        {
            database = new Database();
        }

        public async Task<List<Dictionary<string, object>>> GetAllCommentsAsync()
        {
            return await database.GetAll("comment");
        }

        public async Task<bool> CreateCommentAsync(Comment comment) 
        {
            DocumentReference documentReference = database.db.Collection("comment").Document();

            var result = await documentReference.SetAsync(Comment.MapCommentToDictionary(comment));
            if(result != null)
            {
                return true;
            }

            return false;
        }
    }
}