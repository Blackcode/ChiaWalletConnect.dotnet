using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_getSyncStatus")]
    internal class GetSyncStatus
    {
        public string fingerprint { get; set; }
        public GetSyncStatus(string fingerprint)
        {
            this.fingerprint = fingerprint;
        }
    }
}
