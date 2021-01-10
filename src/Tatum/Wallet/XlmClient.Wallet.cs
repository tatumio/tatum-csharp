using stellar_dotnet_sdk;

namespace Tatum.Clients
{
    public partial class XlmClient : IXlmClient
    {
        Wallet IXlmClient.CreateWallet(string secret)
        {
            KeyPair keypair;
            if (string.IsNullOrWhiteSpace(secret))
            {
                keypair = KeyPair.Random();
            }
            else
            {
                keypair = KeyPair.FromSecretSeed(secret);
            }

            return new Wallet
            {
                PrivateKey = keypair.SecretSeed,
                Address = keypair.Address
            };
        }
    }
}
