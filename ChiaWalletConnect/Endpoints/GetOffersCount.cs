using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_getOffersCount")]
    internal class GetOffersCount {
        public string fingerprint { get; set; }
        public GetOffersCount(string fingerprint)
        {
            this.fingerprint = fingerprint;
        }
    }
}
