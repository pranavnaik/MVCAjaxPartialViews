using ReferenceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReferenceApplication.ViewModel
{
    public class CustomerVM
    {
        public CustomerModel Customer { get; set; }
        public List<CustomerModel> Customers { get; set; }
    }
}