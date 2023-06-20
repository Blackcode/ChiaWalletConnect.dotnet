using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_logIn")]
    internal class LogIn
    {
        public string fingerprint { get; set; }
        public LogIn(string fingerprint)
        {
            this.fingerprint = fingerprint;
        }
    }
}
