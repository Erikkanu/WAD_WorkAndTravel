using WAD_WorkAndTravel.Models;

namespace WAD_WorkAndTravel.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly WAT_Context _context;
        private IJobRepository _job;
        private ITicketRepository _ticket;
        private IUserRepository _user;
        private IRegistrationFormRepository _registrationForm;
        private ITestimonialRepository _testimonial;
        private IGalleryPostRepository _galleryPost;

        public RepositoryWrapper(WAT_Context context)
        {
            _context = context;
        }

        public IJobRepository Job => _job ??= new JobRepository(_context);
        public ITicketRepository Ticket => _ticket ??= new TicketRepository(_context);
        public IUserRepository User => _user ??= new UserRepository(_context);
        public IRegistrationFormRepository RegistrationForm => _registrationForm ??= new RegistrationFormRepository(_context);
        public ITestimonialRepository Testimonial => _testimonial ??= new TestimonialRepository(_context);
        public IGalleryPostRepository GalleryPost => _galleryPost ??= new GalleryPostRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
