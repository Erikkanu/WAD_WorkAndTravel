using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Services
{
    public interface IJobService
    {
        IEnumerable<Job> GetAllJobs();
        Job GetJobById(int id);
        void CreateJob(Job job);
        void UpdateJob(Job job);
        void DeleteJob(Job job);
    }
}
