namespace Tatum.CSharp.Core.Configuration
{
    public class DefaultTatumSdkConfiguration : TatumSdkConfiguration
    {
        public DefaultTatumSdkConfiguration()
        {
            IsTestnet = false;
            BaseUrl = TatumConstants.BaseUrl;
            ApiKey = null;
        }
    }
}