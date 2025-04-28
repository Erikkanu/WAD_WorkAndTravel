using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Services
{
    public interface ITestimonialService
    {
        IEnumerable<Testimonial> GetAllTestimonials();
        Testimonial GetTestimonialById(int id);
        void CreateTestimonial(Testimonial Testimonial);
        void UpdateTestimonial(Testimonial Testimonial);
        void DeleteTestimonial(Testimonial Testimonial);
    }
}
