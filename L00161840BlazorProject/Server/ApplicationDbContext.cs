using L00161840BlazorProject.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Server
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PayData> PayDatum { get; set; }
        public DbSet<PayGroup> PayGroups { get; set; }
        public DbSet<PayItem> PayItems { get; set; }
        public DbSet<PayPeriod> PayPeriods { get; set; }
        public DbSet<PayslipItem> PayslipItems { get; set; }
        public DbSet<Invite> Invites { get; set; }
    }
}
