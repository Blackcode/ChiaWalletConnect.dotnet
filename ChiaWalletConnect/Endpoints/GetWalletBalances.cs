using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_getWalletBalances")]
    internal class GetWalletBalances
    {
        public string fingerprint { get; set; }
        public int[] walletIds { get; set; }
        public GetWalletBalances(string fingerprint, int[] walletIds)
        {
            this.fingerprint = fingerprint;
            this.walletIds = walletIds;
        }
    }
}
