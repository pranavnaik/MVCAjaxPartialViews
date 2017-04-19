using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ReferenceApplication.Models;

namespace ReferenceApplication.Dal
{
    public class CustomerDal: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CustomerModel>().ToTable("EmployeeDetails");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CustomerModel> Customers { get; set; }
    }
}