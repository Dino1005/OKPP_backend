namespace Model
{
    public class Attendance
    {
        public Attendance(string eventId, string userId)
        {
            EventId = eventId;
            UserId = userId;
        }

        public string EventId { get; set; }
        public string UserId { get; set; }

        public static Attendance MapDictionaryToAttendance(Dictionary<string, object> dictionary)
        {
            return new Attendance(dictionary["eventId"].ToString(),
                dictionary["userId"].ToString()
            );
        }

        public static Dictionary<string, object> MapAttendanceToDictionary(Attendance attendance) 
        {
            return new Dictionary<string, object>
            {
                { "eventId", attendance.EventId },
                { "userId", attendance.UserId }
            };
        }
    }
}