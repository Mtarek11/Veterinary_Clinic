using Application.Repositories.Customers;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Customers
{
    public class CustomerCommandRepository(Context context) : CommandRepository<Customer>(context), ICustomerCommandRepository
    {
    }
}
