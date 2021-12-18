using DataPaginator.Example.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPaginator.Example.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
         : base(options)
        { }

        public DbSet<Dog> Dogs { get; set; }
    }
}