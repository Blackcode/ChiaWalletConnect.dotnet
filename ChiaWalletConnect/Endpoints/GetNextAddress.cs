using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_getNextAddress")]
    internal class GetNextAddress
    {
        public string fingerprint { get; set; }
        public int walletId { get; set; }
        public bool newAddress { get; set; }
        public GetNextAddress(string fingerprint, int walletId, bool newAddress)
        {
            this.fingerprint = fingerprint;
            this.walletId = walletId;
            this.newAddress = newAddress;
        }
    }
}
