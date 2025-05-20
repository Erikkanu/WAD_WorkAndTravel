using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;

namespace WAD_WorkAndTravel.Models
{
    public class WAT_Context : IdentityDbContext<IdentityUser>
    {
        public WAT_Context(DbContextOptions<WAT_Context> options)
            : base(options)
        { }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<RegistrationForm> RegistrationForms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<GalleryPost> GalleryPosts { get; set; }
    }
}
