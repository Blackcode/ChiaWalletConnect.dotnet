using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_getTransaction")]
    internal class GetTransaction
    {
        public string fingerprint { get; set; }
        public string transactionId { get; set; }
        public GetTransaction(string fingerprint, string transactionId)
        {
            this.fingerprint = fingerprint;
            this.transactionId = transactionId;
        }
    }
}
