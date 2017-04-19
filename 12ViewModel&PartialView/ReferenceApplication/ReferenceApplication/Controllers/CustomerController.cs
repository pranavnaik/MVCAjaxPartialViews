using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReferenceApplication.Models;
using ReferenceApplication.Dal;
using ReferenceApplication.ViewModel;

namespace ReferenceApplication.Controllers
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase Objctx = controllerContext.HttpContext;
            string CustName = Objctx.Request.Form["txtCustomerName"];
            string CustCode = Objctx.Request.Form["txtCustomerCode"];
            CustomerModel obj = new CustomerModel()
            {
                CustomerCode = CustCode,
                CustomerName = CustName
            };
            return obj;
        }
    }

    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            CustomerModel obj = new CustomerModel { CustomerCode = "1001", CustomerName = "Pranav" };
            return View("Customers", obj);
        }

        public ActionResult Enter()
        {
            CustomerVM obj = new CustomerVM();
            obj.Customer = new CustomerModel();
            CustomerDal dal = new CustomerDal();
            List<CustomerModel> Customerscoll = dal.Customers.ToList<CustomerModel>();
            obj.Customers = Customerscoll;
            return View("EnterCustomers",obj);//first time pass empty object
        }

        public ActionResult Submit()//Validations runs here //if any errors are send to the object called modelstate
        {
            //We can comment the below code and give (CustomerModel obj) as parameter to submit 
            //the obj will get the data correctly since the model property names is same as name 
            //of the controls in the view 
            CustomerVM vm = new CustomerVM();
           

            CustomerModel obj = new CustomerModel();
            obj.CustomerName = Request.Form["Customer.CustomerName"];
            obj.CustomerCode = Request.Form["Customer.CustomerCode"]; 

            //if any errors are send to the object called modelstate

            if(ModelState.IsValid)
            {
                //insert data into database using EF Dal
                CustomerDal Dal = new CustomerDal();
                Dal.Customers.Add(obj); //in-memory updation
                Dal.SaveChanges(); //physical commit
                vm.Customer = new CustomerModel();
        

            }
            else
            {
                vm.Customer = obj;
            }

            CustomerDal dal = new CustomerDal();
            List<CustomerModel> Customerscoll = dal.Customers.ToList<CustomerModel>();
            vm.Customers = Customerscoll;

            return View("EnterCustomers", vm);//to pass the obj to view
                //the view shd be strongly typed view
           
        }

        public ActionResult EnterSearch()
        {
            CustomerVM vm = new CustomerVM();
            vm.Customers = new List<CustomerModel>(); 
            return View("SearchCustomers", vm);
        }

        public ActionResult SearchCustomer()
        {
            CustomerVM vm = new CustomerVM();
            CustomerDal dal = new CustomerDal();
            string str = Request.Form["txtCustomerName"];
            List<CustomerModel> Customerscoll = (from x in dal.Customers
                                                 where x.CustomerName == str
                                                 select x).ToList<CustomerModel>();
            vm.Customers = Customerscoll;
            return View("SearchCustomers", vm);

        } 
    }
}