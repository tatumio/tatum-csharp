using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IOffchainClient
/// </summary>
/// 

namespace Tatum
{
    public interface IOffchainClient
    {
        Task<Common> GenerateDepositAddress(string id);
        Task<List<Common>> GetDepositAddresses(string id);
        Task<List<Common>> GenerateDepositAddresses(string accountid);
        Task<Common> CheckAddressExists(string currency,string address);
        Task<Common> RemoveDepositAddress(string id, string address);
        Task<Common> AssignDepositAddress(string id, string address);



        Task<OffBlockchain> EstimateBlockchainTransactionFee(string senderAccountId, string address,string amount,string multipleAmounts,string attr,string xpub);


        Task<OffBlockchain> SendBitcoinToTatumAddressMnemonic(string senderAccountId, string address, string amount,string fee, string multipleAmounts, string attr,string mnemonic, string xpub,string paymentid,string sendernote);
        Task<OffBlockchain> SendBitcoinToTatumAddressKeyPair(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string accountaddress, string privatekey, string attr,string paymentid, string sendernote);
        Task<OffBlockchain> SendBitcoinToTatumAddressKms(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string signatureid, string xpub, string paymentid, string sendernote);


        Task<OffBlockchain> SendBcashToTatumAddressMnemonic(string senderAccountId, string address, string amount, string fee, string multipleAmounts,string accountaddress,string privatekey, string attr,  string paymentid, string sendernote);
        Task<OffBlockchain> SendBcashToTatumAddressKeyPair(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string accountaddress, string privatekey, string attr, string paymentid, string sendernote);
        Task<OffBlockchain> SendBcashToTatumAddressKms(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string signatureid, string xpub, string paymentid, string sendernote);

        Task<OffBlockchain> SendLitecoinToTatumAddressMnemonic(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string mnemonic, string xpub, string paymentid, string sendernote);
        Task<OffBlockchain> SendLitecoinToTatumAddressKeyPair(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string addressto, string privatekey, string paymentid, string sendernote);
        Task<OffBlockchain> SendLitecoinToTatumAddressKms(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string signatureid, string xpub, string paymentid, string sendernote);

        Task<OffBlockchain> SendDogecoinToTatumAddressMnemonic(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string mnemonic, string xpub, string paymentid, string sendernote);
        Task<OffBlockchain> SendDogecoinToTatumAddressKeyPair(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string addressto, string privatekey, string paymentid, string sendernote);
        Task<OffBlockchain> SendDogecoinToTatumAddressKms(string senderAccountId, string address, string amount, string fee, string multipleAmounts, string attr, string signatureid, string xpub, string paymentid, string sendernote);


        Task<OffBlockchain> SendFlowToTatumAddressMnemonic(string senderAccountId,string account, string address, string amount, string mnemonic, string index,string compliant, string paymentid, string sendernote);
        Task<OffBlockchain> SendFlowToTatumAddressPK(string senderAccountId, string account, string address, string amount, string privateKey, string compliant, string paymentid, string sendernote);
        Task<OffBlockchain> SendFlowToTatumAddressKms(string senderAccountId, string account, string address, string amount,  string signatureid, string index, string compliant, string paymentid, string sendernote);


        Task<OffBlockchain> SendEthereumToTatumAddress( string address, string amount, string compliant, string privateKey, string paymentid, string senderAccountId, string sendernote,string gasLimit,string gasPrice);
        Task<OffBlockchain> SendEthereumToTatumAddressMnemonic(string address, string amount, string compliant, string index,  string gasLimit, string gasPrice,string mnemonic, string paymentid, string senderAccountId, string sendernote);
        Task<OffBlockchain> SendEthereumToTatumAddressKms(string address, string amount, string compliant, string signatureid, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice);


        Task<OffBlockchain> SendErc20ToTatumAddress(string address, string amount, string compliant, string privateKey, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice);
        Task<OffBlockchain> SendErc20ToTatumAddressMnemonic(string address, string amount, string compliant, string index, string gasLimit, string gasPrice, string mnemonic, string paymentid, string senderAccountId, string sendernote);
        Task<OffBlockchain> SendErc20ToTatumAddressKms(string address, string amount, string compliant, string signatureid, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice);


        Task<OffBlockchain> RegisterNewErc20(string symbol, string supply, double decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry,string externalid,string providercountry, string derivationindex,  string xpub );
        Task<OffBlockchain> RegisterNewErc20ByAddress(string symbol, string supply, double decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address);


        Task<OffBlockchain> DeployErc20OffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic,int index);
        Task<OffBlockchain> DeployErc20OffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub,string derivationindex, string mnemonic, int index);
        Task<OffBlockchain> DeployErc20OffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey);
        Task<OffBlockchain> DeployErc20OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey);
        Task<OffBlockchain> DeployErc20OffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid);
        Task<OffBlockchain> DeployErc20OffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid);



        Task<OffBlockchain> OffchainTransferBsc(string address, string amount, string compliant, string privatekey, string paymentid, string senderaccountid, string sendernote, string gaslimit, string gasprice);
        Task<OffBlockchain> OffchainTransferBscMnemonic(string address, string amount, string compliant, string index, string gaslimit, string gasprice,string mnemonic, string paymentid, string senderaccountid, string sendernote );
        Task<OffBlockchain> OffchainTransferBscKMS(string address, string amount, string compliant,string signatureid, string index, string paymentid, string senderaccountid, string sendernote, string gaslimit, string gasprice );



        Task<OffBlockchain> RegisterNewBEP20Erc20(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry,string derivationindex,string xpub);
        Task<OffBlockchain> RegisterNewBEP20Erc20Address(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address);


        Task<OffBlockchain> DeployBscBEP20OffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index);
        Task<OffBlockchain> DeployBscBEP20OffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index);
        Task<OffBlockchain> DeployBscBEP20OffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey);
        Task<OffBlockchain> DeployBscBEP20OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey);
        Task<OffBlockchain> DeployBscBEP20OffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid);
        Task<OffBlockchain> DeployBscBEP20OffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid);




        Task<OffBlockchain> SendXDCFromLedgerToBlockchain(string address, string amount, string compliant, string privateKey, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice);
        Task<OffBlockchain> SendXDCFromLedgerToBlockchainMnemonic(string address, string amount, string compliant, string index, string gasLimit, string gasPrice, string mnemonic, string paymentid, string senderAccountId, string sendernote);
        Task<OffBlockchain> SendXDCFromLedgerToBlockchainKms(string address, string amount, string compliant, string signatureid, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice);


        Task<OffBlockchain> RegisterNewXDCErc20(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string derivationindex, string xpub);
        Task<OffBlockchain> RegisterNewXDCErc20Address(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address);



        Task<OffBlockchain> DeployXDCErc20OffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index);
        Task<OffBlockchain> DeployXDCErc20OffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index);
        Task<OffBlockchain> DeployXDCErc20OffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey);
        Task<OffBlockchain> DeployXDCErc20OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey);
        Task<OffBlockchain> DeployXDCErc20OffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid);
        Task<OffBlockchain> DeployXDCErc20OffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid);



        Task<OffBlockchain> SendONEFromLedgerToBlockchain(string address, string amount, string compliant, string privateKey, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice);
        Task<OffBlockchain> SendONEFromLedgerToBlockchainMnemonic(string address, string amount, string compliant, string index, string gasLimit, string gasPrice, string mnemonic, string paymentid, string senderAccountId, string sendernote);
        Task<OffBlockchain> SendONEFromLedgerToBlockchainKms(string address, string amount, string compliant, string signatureid, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice);



        Task<OffBlockchain> RegisterNewONEErc20(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string derivationindex, string xpub);
        Task<OffBlockchain> RegisterNewONEErc20Address(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address);



        Task<OffBlockchain> DeployONEErc20OffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index);
        Task<OffBlockchain> DeployONEErc20OffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index);
        Task<OffBlockchain> DeployONEErc20OffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey);
        Task<OffBlockchain> DeployONEErc20OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey);
        Task<OffBlockchain> DeployONEErc20OffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid);
        Task<OffBlockchain> DeployONEErc20OffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid);



        Task<OffBlockchain> SetErc20BEP20HRM20TRC20Token(string address, string name);


        Task<OffBlockchain> SendCeloFromLedgerToBlockchain(string address, string amount, string compliant, string privateKey, string paymentid, string senderAccountId,string feecurrency, string sendernote, string gasLimit, string gasPrice);
        Task<OffBlockchain> SendCeloFromLedgerToBlockchainMnemonic(string address, string amount, string compliant, string index,string feecurrency, string gasLimit, string gasPrice, string mnemonic, string paymentid, string senderAccountId, string sendernote);
        Task<OffBlockchain> SendCeloFromLedgerToBlockchainKms(string address, string amount, string compliant, string signatureid,string feecurrency, string paymentid, string senderAccountId, string sendernote, string gasLimit, string gasPrice);



        Task<OffBlockchain> RegisterNewCeloErc20(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string derivationindex, string xpub);
        Task<OffBlockchain> RegisterNewCeloErc20Address(string symbol, string supply, string decimals, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address);



        Task<OffBlockchain> DeployCeloErc20OffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index,string feecurrency);
        Task<OffBlockchain> DeployCeloErc20OffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index,string feecurrency);
        Task<OffBlockchain> DeployCeloErc20OffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey,string feecurrency);
        Task<OffBlockchain> DeployCeloErc20OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey,string feecurrency);
        Task<OffBlockchain> DeployCeloErc20OffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid,string feecurrency);
        Task<OffBlockchain> DeployCeloErc20OffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid,string feecurrency);



        Task<OffBlockchain> SetCeloTokenAddress(string address, string name);


        Task<OffBlockchain> SendXlmFromLedgerToBlockchain(string senderAccountId, string fromaccount, string address, string amount, string secret,  string compliant,string attr, string paymentid, string sendernote);
        Task<OffBlockchain> SendXlmFromLedgerToBlockchainKms(string senderAccountId, string fromaccount, string address, string amount, string signatureid, string compliant, string attr, string paymentid, string sendernote);


        Task<OffBlockchain> CreateXlmBasedAsset(string issueraccount, string token,string basepair);


        Task<OffBlockchain> SendXRpFromLedgerToBlockchain(string senderAccountId, string account, string address, string amount,  string compliant, string attr, string paymentid, string secret, string sendernote);
        Task<OffBlockchain> SendXRpFromLedgerToBlockchainKms(string senderAccountId, string account, string address, string amount, string compliant, string attr, string paymentid, string signatureid, string sendernote);


        Task<OffBlockchain> CreateXRPBasedAsset(string issueraccount, string token, string basepair);


        Task<OffBlockchain> SendBnbFromLedgerToBlockchain(string senderAccountId,string address, string amount, string compliant, string attr, string paymentid, string privatekey, string sendernote);
        Task<OffBlockchain> SendBnbFromLedgerToBlockchainKms(string senderAccountId, string address, string amount, string compliant, string attr, string paymentid, string signatureid,string fromaddress, string sendernote);


        Task<OffBlockchain> CreateBnbBasedAsset(string token, string basepair);


        Task<OffBlockchain> SendAdaFromLedgerToBlockchain(string senderAccountId,string address, string amount, string compliant,string fee,string addressfrom, string privatekey, string attr, string mnemonic,string signatureid,string xpub,string paymentid,string sendernote);
        Task<OffBlockchain> SendAdaFromLedgerToBlockchainMnemonic(string address, string amount, string compliant,string fee, string index, string mnemonic, string paymentid, string senderAccountId, string sendernote);
        Task<OffBlockchain> SendAdaFromLedgerToBlockchainKms(string address, string amount, string compliant,string fee,string from, string signatureid, string index, string paymentid, string senderAccountId, string sendernote);


        Task<OffBlockchain> SendTronFromLedgerToBlockchain( string address, string amount, string compliant,string privatekey, string fee, string paymentid, string senderAccountId, string sendernote);
        Task<OffBlockchain> SendTronFromLedgerToBlockchainMnemonic(string address, string amount, string compliant, string fee, string index, string mnemonic, string paymentid, string senderAccountId, string sendernote);
        Task<OffBlockchain> SendTronFromLedgerToBlockchainKms(string address, string amount, string compliant, string fee, string from, string signatureid, string index, string paymentid, string senderAccountId, string sendernote);


        Task<OffBlockchain> RegisterNewTrc1020InLedger(string symbol, string supply, double decimals,string type, string description,string url, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string derivationindex, string xpub,string address);


        Task<OffBlockchain> DeployTrcOffchainMnemonicAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string mnemonic, int index);
        Task<OffBlockchain> DeployTrcffchainMnemXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string mnemonic, int index);
        Task<OffBlockchain> DeployTrcOffchainPKAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string privatekey);
        Task<OffBlockchain> DeployTrc0OffchainPKXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, int privatekey);
        Task<OffBlockchain> DeployTrcOffchainKMSAddress(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string address, string signatureid);
        Task<OffBlockchain> DeployTrcOffchainKMSXpub(string symbol, string supply, string description, string basepair, string baserate, string accountingcurrency, string customercountry, string externalid, string providercountry, string xpub, string derivationindex, string signatureid);



        Task<OffBlockchain> SetTrcContractAddress(string address, string name);

        Task<OffBlockchain> StoreWithdrawalOffchain(string senderaccountid, string address, double amount, string attr, string compliant, string fee, string multipleamounts, string paymentid, string sendernote);

        Task<OffBlockchain> GetWithdrawalsOffchain(string currency, string status, int pagesize);

        Task<OffBlockchain> CompleteWithdrawalOffchain(string id, string txid);
        Task<OffBlockchain> CancelWithdrawalOffchain(string id, string revert);
        Task<OffBlockchain> BroadcastSignedTransactionOffchain(string currency, string txdata, string withdrawalid,string signatureid);
    }

}