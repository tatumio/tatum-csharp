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
            return tatumApi.CreateVirtualCurrency(currency);
        }

        Task ITatumClient.UpdateVirtualCurrency(UpdateVirtualCurrency currency)
        {
            return tatumApi.UpdateVirtualCurrency(currency);
        }

        Task<string> ITatumClient.MintVirtualCurrency(CurrencyOperation operation)
        {
            return tatumApi.MintVirtualCurrency(operation);
        }

        Task<string> ITatumClient.RevokeVirtualCurrency(CurrencyOperation operation)
        {
            return tatumApi.RevokeVirtualCurrency(operation);
        }
    }
}
