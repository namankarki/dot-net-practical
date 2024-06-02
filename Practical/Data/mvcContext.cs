using Microsoft.EntityFrameworkCore;
using Practical.Models;

namespace Practical.Data
{
    public class mvcContext : DbContext
    {

        public mvcContext(DbContextOptions<mvcContext> options)
            : base(options)
        {
        }

        public DbSet<Practical.Models.agentmodel> Agentmodel{ get; set; }
        public DbSet<Practical.Models.Bag> Books
        { get; set; }
        public DbSet<Practical.Models.Employee> Employee { get; set; }


    }

            
    
}
