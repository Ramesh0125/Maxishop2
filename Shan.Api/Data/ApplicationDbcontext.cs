using Microsoft.EntityFrameworkCore;
using Shan.Api.Model;

namespace Shan.Api.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }

    }
}
