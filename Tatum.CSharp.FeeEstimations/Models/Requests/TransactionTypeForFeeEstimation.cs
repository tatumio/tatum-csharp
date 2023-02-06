namespace Tatum.CSharp.FeeEstimations.Models.Requests
{
    public enum TransactionTypeForFeeEstimation
    {
        DEPLOY_ERC20 = 1,
        DEPLOY_NFT,
        MINT_NFT,
        BURN_NFT,
        TRANSFER_NFT,
        TRANSFER_ERC20,
        DEPLOY_AUCTION,
        DEPLOY_MARKETPLACE
    }
}