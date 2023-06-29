using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_signMessageById")]
    internal class SignMessageById
    {
        public string fingerprint { get; set; }
        public string id { get; set; }
        public string message { get; set; }

        public SignMessageById(string fingerprint, string id, string message)
        {
            this.fingerprint = fingerprint;
            this.id = id;
            this.message = message;
        }
    }
}
