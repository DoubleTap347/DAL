using FreelancersDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancersDAL.Services
{
    public interface ICustomerService
    {
        //Declare new methods
        List<Customer> RetrieveCustomers();
        List<Customer> RetrieveCustomersWithProjects();
        Customer RetrieveCustomersByLastName(string lastname);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
        DataSet GetDisconnectedData();
    }
}