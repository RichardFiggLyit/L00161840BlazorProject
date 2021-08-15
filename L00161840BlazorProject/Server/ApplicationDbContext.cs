using L00161840BlazorProject.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Server
{
    public class ApplicationDbContext: IdentityDbContext
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

        public DbSet<AnnualLeaveEntitlement> AnnualLeaveEntitlements { get; set; }
        public DbSet<AnnualLeaveRequest> AnnualLeaveRequests { get; set; }
        public DbSet<AnnualLeaveTaken> AnnualLeaveTaken { get; set; }
    }
}
