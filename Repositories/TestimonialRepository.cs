using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Repositories
{
    public class TestimonialRepository : RepositoryBase<Testimonial>, ITestimonialRepository
    {
        public TestimonialRepository(WAT_Context context) : base(context)
        {
        }
    }
}
