using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class TatumClient : ITatumClient
    {
        Task<List<Transaction>> ITatumClient.GetTransactions(string reference)
        {
            return tatumApi.GetTransactions(reference);
        }

        Task<string> ITatumClient.StoreTransaction(CreateTransaction transaction)
        {
            var validationContext = new ValidationContext(transaction);
            Validator.ValidateObject(transaction, validationContext, validateAllProperties: true);

            return tatumApi.StoreTransaction(transaction);
        }

        Task<List<Transaction>> ITatumClient.GetTransactionsForAccount(TransactionFilterAccount filter, int pageSize, int offset)
        {
            var validationContext = new ValidationContext(filter);
            Validator.ValidateObject(filter, validationContext, validateAllProperties: true);

            return tatumApi.GetTransactionsForAccount(filter, pageSize, offset);
        }

        Task<List<Transaction>> ITatumClient.GetTransactionsForCustomer(TransactionFilterCustomer filter, int pageSize, int offset)
        {
            var validationContext = new ValidationContext(filter);
            Validator.ValidateObject(filter, validationContext, validateAllProperties: true);

            return tatumApi.GetTransactionsForCustomer(filter, pageSize, offset);
        }

        Task<List<Transaction>> ITatumClient.GetTransactionsForLedger(TransactionFilterLedger filter, int pageSize, int offset)
        {
            var validationContext = new ValidationContext(filter);
            Validator.ValidateObject(filter, validationContext, validateAllProperties: true);

            return tatumApi.GetTransactionsForLedger(filter, pageSize, offset);
        }

        Task<int> ITatumClient.CountTransactionsForAccount(TransactionFilterAccount filter)
        {
            var validationContext = new ValidationContext(filter);
            Validator.ValidateObject(filter, validationContext, validateAllProperties: true);

            return tatumApi.CountTransactionsForAccount(filter);
        }

        Task<int> ITatumClient.CountTransactionsForCustomer(TransactionFilterCustomer filter)
        {
            var validationContext = new ValidationContext(filter);
            Validator.ValidateObject(filter, validationContext, validateAllProperties: true);

            return tatumApi.CountTransactionsForCustomer(filter);
        }
        Task<int> ITatumClient.CountTransactionsForLedger(TransactionFilterLedger filter)
        {
            var validationContext = new ValidationContext(filter);
            Validator.ValidateObject(filter, validationContext, validateAllProperties: true);

            return tatumApi.CountTransactionsForLedger(filter);
        }
    }
}
