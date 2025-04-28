using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Repositories;

namespace WAD_WorkAndTravel.Services
{
    public class JobService : IJobService
    {
        private readonly IRepositoryWrapper _repository;

        public JobService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return _repository.Job.FindAll().ToList();
        }

        public Job GetJobById(int id)
        {
            return _repository.Job.FindByCondition(j => j.JobID == id).FirstOrDefault();
        }

        public void CreateJob(Job job)
        {
            _repository.Job.Create(job);
            _repository.Save();
        }

        public void UpdateJob(Job job)
        {
            _repository.Job.Update(job);
            _repository.Save();
        }

        public void DeleteJob(Job job)
        {
            _repository.Job.Delete(job);
            _repository.Save();
        }
    }
}
