using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_getCurrentAddress")]
    internal class GetCurrentAddress {
        public string fingerprint { get; set; }
        public int walletId { get; set; }
        public GetCurrentAddress(string fingerprint, int walletId)
        {
            this.fingerprint = fingerprint;
            this.walletId = walletId;
        }
    }
}
