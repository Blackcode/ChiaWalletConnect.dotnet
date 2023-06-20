using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_getWallets")]
    internal class GetWallets
    {
        public string fingerprint { get; set; }
        public bool includeData { get; set; }
        public GetWallets(string fingerprint, bool includeData)
        {
            this.fingerprint = fingerprint;
            this.includeData = includeData;
        }
    }
}
