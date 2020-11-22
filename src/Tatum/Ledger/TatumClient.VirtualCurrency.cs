using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class TatumClient : ITatumClient
    {
        Task<VirtualCurrency> ITatumClient.GetVirtualCurrency(string virtualCurrencyName)
        {
            return tatumApi.GetVirtualCurrency(virtualCurrencyName);
        }

        Task<Account> ITatumClient.CreateVirtualCurrency(CreateVirtualCurrency currency)
        {
            var validationContext = new ValidationContext(currency);
            Validator.ValidateObject(currency, validationContext, validateAllProperties: true);

            return tatumApi.CreateVirtualCurrency(currency);
        }

        Task ITatumClient.UpdateVirtualCurrency(UpdateVirtualCurrency currency)
        {
            var validationContext = new ValidationContext(currency);
            Validator.ValidateObject(currency, validationContext, validateAllProperties: true);

            return tatumApi.UpdateVirtualCurrency(currency);
        }

        Task<string> ITatumClient.MintVirtualCurrency(CurrencyOperation operation)
        {
            var validationContext = new ValidationContext(operation);
            Validator.ValidateObject(operation, validationContext, validateAllProperties: true);
            
            return tatumApi.MintVirtualCurrency(operation);
        }

        Task<string> ITatumClient.RevokeVirtualCurrency(CurrencyOperation operation)
        {
            var validationContext = new ValidationContext(operation);
            Validator.ValidateObject(operation, validationContext, validateAllProperties: true);

            return tatumApi.RevokeVirtualCurrency(operation);
        }
    }
}
