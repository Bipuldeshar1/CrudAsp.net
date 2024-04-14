using CrudAsp.net.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAsp.net.Dbcontext
{
    public class CRUDDbcontext:DbContext
    {
        public CRUDDbcontext(DbContextOptions options):base(options) { }

        public DbSet<Product> products { get; set; }    
    }
}
