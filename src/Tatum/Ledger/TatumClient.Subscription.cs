using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class TatumClient : ITatumClient
    {
        Task<string> ITatumClient.CreateSubscription(CreateSubscription subscription)
        {
            var validationContext = new ValidationContext(subscription);
            Validator.ValidateObject(subscription, validationContext, validateAllProperties: true);

            return tatumApi.CreateSubscription(subscription);
        }

        Task<List<Subscription>> ITatumClient.GetActiveSubscriptions(int pageSize, int offset)
        {
            return tatumApi.GetActiveSubscriptions(pageSize, offset);
        }

        Task ITatumClient.CancelExistingSubscription(string subscriptionId)
        {
            return tatumApi.CancelExistingSubscription(subscriptionId);
        }

        Task<object> ITatumClient.ObtainReport(string subscriptionId)
        {
            return tatumApi.ObtainReport(subscriptionId);
        }
    }
}
