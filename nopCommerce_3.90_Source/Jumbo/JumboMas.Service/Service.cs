using Nop.Core.Domain.Customers;
using Nop.Services.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumboMas.Service
{
    public class Service
    {
        //MOCK RESULT
        public CustomerRole GetAssociateCustomerRole(ICustomerService serviceNop)
        {
            List<CustomerRole> _roles = serviceNop.GetAllCustomerRoles().ToList();

            //Call Service and Get de Role Name for the current user
            CustomerRole _role = new CustomerRole() { Name = "Socio" };
            return _roles.Where(r => r.Name == _role.Name).FirstOrDefault();
        }
    }
}
