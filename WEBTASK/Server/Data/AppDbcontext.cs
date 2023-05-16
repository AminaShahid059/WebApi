using Microsoft.EntityFrameworkCore;
using WEBTASK.Shared;

namespace WEBTASK.Server.Data
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options):base (options) 
        {
            
        }
        public DbSet<Order> Order { get; set; }


    }
}
