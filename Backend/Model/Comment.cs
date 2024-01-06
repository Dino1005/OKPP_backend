using Google.Cloud.Firestore;

namespace Model
{
    public class Comment
    {
        public Comment(string eventId, string userId, DateTime date, string message)
        {
            EventId = eventId;
            UserId = userId;
            Date = date;
            Message = message;
        }

        public string EventId { get; set; }
        public string UserId { get; set; }
        public DateTime Date {  get; set; }
        public string Message {  get; set; }

        public static Comment MapDictionaryToComment(Dictionary<string, object> dictionary)
        {
            return new Comment(dictionary["eventId"].ToString(),
                dictionary["userId"].ToString(),
                ((Timestamp)dictionary["date"]).ToDateTime(),
                dictionary["message"].ToString()
            );
        }

        public static Dictionary<string, object> MapCommentToDictionary(Comment comment) 
        {
            return new Dictionary<string, object>
            {
                { "eventId", comment.EventId },
                { "userId", comment.UserId },
                { "date", comment.Date },
                { "message", comment.Message }
            };
        }
    }
}