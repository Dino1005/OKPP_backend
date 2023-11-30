using Google.Cloud.Firestore;

namespace Model
{
    public class User
    {
        public User(string id, string address, string city, DateTime dob, string firstName, string lastName, List<string> preferences)
        {
            Id = id;
            Address = address;
            City = city;
            Dob = dob;
            FirstName = firstName;
            LastName = lastName;
            Preferences = preferences;
        }

        public User()
        {
                
        }

        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime Dob {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Preferences { get; set; }

        public static User MapDictionaryToUser(Dictionary<string, object> dictionary)
        {
            return new User
            {
                Id = dictionary["id"].ToString(),
                Address = dictionary["address"].ToString(),
                City = dictionary["city"].ToString(),
                Dob = ((Timestamp)dictionary["dob"]).ToDateTime(),
                FirstName = dictionary["firstName"].ToString(),
                LastName = dictionary["lastName"].ToString(),
                Preferences = ((List<object>)dictionary["preferences"]).Select(o => o.ToString()).ToList()
            };
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
                { "preferences", user.Preferences }
            };
        }
    }
}