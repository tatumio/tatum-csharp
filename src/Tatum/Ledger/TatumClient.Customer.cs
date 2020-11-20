using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class TatumClient : ITatumClient
    {
        Task<Customer> ITatumClient.GetCustomer(string customerId)
        {
            return tatumApi.GetCustomer(customerId);
        }

        Task<List<Customer>> ITatumClient.GetCustomers(int pageSize, int offset)
        {
            return tatumApi.GetCustomers(pageSize, offset);
        }

        Task<Customer> ITatumClient.UpdateCustomer(string customerInternalId, UpdateCustomer customer)
        {
            return tatumApi.UpdateCustomer(customerInternalId, customer);
        }

        Task ITatumClient.ActivateCustomer(string customerInternalId)
        {
            return tatumApi.ActivateCustomer(customerInternalId);
        }

        Task ITatumClient.DeactivateCustomer(string customerInternalId)
        {
            return tatumApi.DeactivateCustomer(customerInternalId);
        }

        Task ITatumClient.EnableCustomer(string customerInternalId)
        {
            return tatumApi.EnableCustomer(customerInternalId);
        }

        Task ITatumClient.DisableCustomer(string customerInternalId)
        {
            return tatumApi.DisableCustomer(customerInternalId);
        }
    }
}
