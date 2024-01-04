using Google.Cloud.Firestore;

namespace Model
{
    public class User
    {
        public User(string id, string address, string city, DateTime dob, string firstName, string lastName, List<string> eventTypeIds)
        {
            Id = id;
            Address = address;
            City = city;
            Dob = dob;
            FirstName = firstName;
            LastName = lastName;
            EventTypeIds = eventTypeIds;
        }

        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime Dob {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> EventTypeIds { get; set; }
        public List<EventType> EventTypes { get; set; }
        public List<Event> Events { get; set; }

        public static User MapDictionaryToUser(Dictionary<string, object> dictionary)
        {
            return new User(dictionary["id"].ToString(),
                dictionary["address"].ToString(),
                dictionary["city"].ToString(),
                ((Timestamp)dictionary["dob"]).ToDateTime(),
                dictionary["firstName"].ToString(),
                dictionary["lastName"].ToString(),
                ((List<object>)dictionary["eventTypeIds"]).Select(o => o.ToString()).ToList()
            );
        }

        public static Dictionary<string, object> MapUserToDictionary(User user) 
        {
            return new Dictionary<string, object>
            {
                { "id", user.Id },
                { "address", user.Address },
                { "city", user.City },
                { "dob", user.Dob },
                { "firstName", user.FirstName },
                { "lastName", user.LastName },
                { "eventTypeIds", user.EventTypeIds }
            };
        }
    }
}