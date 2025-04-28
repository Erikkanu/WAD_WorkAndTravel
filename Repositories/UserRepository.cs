using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(WAT_Context context) : base(context)
        {
        }
    }
}
