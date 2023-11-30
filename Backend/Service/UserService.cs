using Model;
using Repository;

namespace Service
{
    public class UserService
    {
        private readonly UserRepository repository;
        public UserService()
        {
            repository = new UserRepository();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var userDictionaries = await repository.GetAllUsersAsync();

            var users = new List<User>();

            foreach (var user in userDictionaries)
            {
                users.Add(User.MapDictionaryToUser(user));
            }

            return users;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var userDictionary = await repository.GetUserByIdAsync(id);

            return userDictionary == null ? null : User.MapDictionaryToUser(userDictionary);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            return await repository.CreateUserAsync(user);
        }
    }
}