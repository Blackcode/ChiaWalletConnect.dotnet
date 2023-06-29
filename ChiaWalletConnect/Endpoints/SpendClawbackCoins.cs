using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_spendClawbackCoins")]
    internal class SpendClawbackCoins
    {
        public string fingerprint { get; set; }
        public string[] coinIds { get; set; }
        public int walletId { get; set; }
        public ulong fee { get; set; }
        public SpendClawbackCoins(string fingerprint, int walletId, string[] coinIds, ulong fee)
        {
            this.fingerprint = fingerprint;
            this.walletId = walletId;
            this.coinIds = coinIds;
            this.fee = fee;
        }
    }
}
