using System.Threading.Tasks;

namespace Tatum.CSharp.Utils
{
    public interface ITatumUtils
    {
        Task WaitForTransactionAsync(string transactionHash);
    }
}