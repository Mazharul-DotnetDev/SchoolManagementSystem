using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.SchoolContext
{

    /*
     IDesignTimeDbContextFactory:

     It enables Entity Framework Core tools to create instances of a DbContext class for design-time operations, such as:
        Generating database migrations
        Scaffolding CRUD (Create, Read, Update, Delete) controllers and views
     */

    public class DbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
    {
        public SchoolDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<SchoolDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database = SchoolSystemDb; Trusted_Connection=True;  trust server certificate = true;");

            return new SchoolDbContext(optionBuilder.Options);

        }
    }
}
