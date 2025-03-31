using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;
using WAD_WorkAndTravel.Models;

namespace AspNetCoreEFCoreApp.Models
{
    public class WAT_Context : DbContext
    {
        public WAT_Context(DbContextOptions<WAT_Context> options)
            : base(options)
        { }
        public DbSet<Job>? Jobs { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }
        public DbSet<RegistrationForm>? Registrations { get; set; }
    }
}
