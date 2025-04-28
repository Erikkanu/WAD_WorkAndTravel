using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Repositories
{
    public class JobRepository : RepositoryBase<Job>, IJobRepository
    {
        public JobRepository(WAT_Context context) : base(context)
        {
        }
    }
}
