namespace WAD_WorkAndTravel.Repositories
{
    public interface IRepositoryWrapper
    {
        IJobRepository Job { get; }
        ITicketRepository Ticket { get; }
        IUserRepository User { get; }
        IRegistrationFormRepository RegistrationForm { get; }
        ITestimonialRepository Testimonial { get; }
        IGalleryPostRepository GalleryPost { get; }
        void Save();
    }
}
