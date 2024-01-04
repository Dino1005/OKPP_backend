namespace Model
{
    public class EventType
    {
        public EventType(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public static EventType MapDictionaryToEventType(Dictionary<string, object> dictionary)
        {
            return new EventType(dictionary["id"].ToString(), dictionary["name"].ToString());
        }

        public static Dictionary<string, object> MapEventTypeToDictionary(EventType eventType) 
        {
            return new Dictionary<string, object>
            {
                { "id", eventType.Id },
                { "name", eventType.Name }
            };
        }
    }
}