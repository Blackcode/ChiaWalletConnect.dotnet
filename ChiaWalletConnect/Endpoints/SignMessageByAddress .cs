using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_signMessageByAddress")]
    internal class SignMessageByAddress
    {
        public string fingerprint { get; set; }
        public string address { get; set; }
        public string message { get; set; }

        public SignMessageByAddress(string fingerprint, string address, string message)
        {
            this.fingerprint = fingerprint;
            this.address = address;
            this.message = message;
        }
    }
}
