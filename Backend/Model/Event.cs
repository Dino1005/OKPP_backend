using Google.Cloud.Firestore;

namespace Model
{
    public class Event
    {
        public Event(string id, string address, string city, DateTime date, string description, string eventTypeId, string imagePath, string location, string name, double price)
        {
            Id = id;
            Address = address;
            City = city;
            Date = date;
            Description = description;
            EventTypeId = eventTypeId;
            ImagePath = imagePath;
            Location = location;
            Name = name;
            Price = price;
        }

        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime Date {  get; set; }
        public string Description {  get; set; }
        public string EventTypeId {  get; set; }
        public EventType EventType {  get; set; }
        public string ImagePath {  get; set; }
        public string Location {  get; set; }
        public string Name {  get; set; }
        public double Price {  get; set; }
        public List<User> Users { get; set; }

        public static Event MapDictionaryToEvent(Dictionary<string, object> dictionary)
        {
            return new Event(dictionary["id"].ToString(),
                dictionary["address"].ToString(),
                dictionary["city"].ToString(),
                ((Timestamp)dictionary["date"]).ToDateTime(),
                dictionary["description"].ToString(),
                dictionary["eventTypeId"].ToString(),
                dictionary["imagePath"].ToString(),
                dictionary["location"].ToString(),
                dictionary["name"].ToString(),
                double.Parse(dictionary["price"].ToString())
            );
        }

        public static Dictionary<string, object> MapEventToDictionary(Event _event) 
        {
            return new Dictionary<string, object>
            {
                { "id", _event.Id },
                { "address", _event.Address },
                { "city", _event.City },
                { "date", _event.Date },
                { "description", _event.Description },
                { "eventTypeId", _event.EventTypeId },
                { "imagePath", _event.ImagePath },
                { "location", _event.Location },
                { "name", _event.Name },
                { "price", _event.Price }
            };
        }
    }
}