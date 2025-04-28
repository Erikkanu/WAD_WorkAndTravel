using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Repositories
{
    public class RegistrationFormRepository : RepositoryBase<RegistrationForm>, IRegistrationFormRepository
    {
        public RegistrationFormRepository(WAT_Context context) : base(context)
        {
        }
    }
}
