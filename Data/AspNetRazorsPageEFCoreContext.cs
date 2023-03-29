using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetRazorsPageEFCore.Models;

namespace AspNetRazorsPageEFCore.Data
{
    public class AspNetRazorsPageEFCoreContext : DbContext
    {
        public AspNetRazorsPageEFCoreContext (DbContextOptions<AspNetRazorsPageEFCoreContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetRazorsPageEFCore.Models.Student>? Student { get; set; }
    }
}
