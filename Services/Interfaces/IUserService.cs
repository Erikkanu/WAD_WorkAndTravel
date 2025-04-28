using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User User);
        void UpdateUser(User User);
        void DeleteUser(User User);
    }
}
