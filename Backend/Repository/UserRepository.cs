using Google.Cloud.Firestore;
using Model;

namespace Repository
{
    public class UserRepository
    {
        private readonly Database database;

        public UserRepository()
        {
            database = new Database();
        }

        public async Task<List<Dictionary<string, object>>> GetAllUsersAsync()
        {
            return await database.GetAll("user");
        }

        public async Task<Dictionary<string, object>> GetUserByIdAsync(string id)
        {
            return await database.GetById("user", id);
        }

        public async Task<bool> CreateUserAsync(User user) 
        {
            DocumentReference documentReference = database.db.Collection("user").Document(user.Id);
            var test = await documentReference.SetAsync(User.MapUserToDictionary(user));
            if(test != null)
            {
                return true;
            }

            return false;
        }
    }
}