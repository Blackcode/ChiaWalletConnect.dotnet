using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_getWalletBalance")]
    internal class GetWalletBalance
    {
        public string fingerprint { get; set; }
        public int walletId { get; set; }
        public GetWalletBalance(string fingerprint, int walletId)
        {
            this.fingerprint = fingerprint;
            this.walletId = walletId;
        }
    }
}
