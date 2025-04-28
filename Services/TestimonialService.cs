using WAD_WorkAndTravel.Models;
using WAD_WorkAndTravel.Repositories;

namespace WAD_WorkAndTravel.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IRepositoryWrapper _repository;

        public TestimonialService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IEnumerable<Testimonial> GetAllTestimonials()
        {
            return _repository.Testimonial.FindAll().ToList();
        }

        public Testimonial GetTestimonialById(int id)
        {
            return _repository.Testimonial.FindByCondition(j => j.id == id).FirstOrDefault();
        }

        public void CreateTestimonial(Testimonial Testimonial)
        {
            _repository.Testimonial.Create(Testimonial);
            _repository.Save();
        }

        public void UpdateTestimonial(Testimonial Testimonial)
        {
            _repository.Testimonial.Update(Testimonial);
            _repository.Save();
        }

        public void DeleteTestimonial(Testimonial Testimonial)
        {
            _repository.Testimonial.Delete(Testimonial);
            _repository.Save();
        }
    }
}
