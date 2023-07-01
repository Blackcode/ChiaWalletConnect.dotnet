using Newtonsoft.Json;
using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_verifySignature")]
    internal class VerifySignature
    {
        public string fingerprint { get; set; }
        public string message { get; set; }
        public string pubkey { get; set; }
        public string signature { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? address { get; set; }
        public string? signingMode { get; set; }

        public VerifySignature(string fingerprint, string message, string pubkey, string signature, string? address, string? signingMode)
        {
            this.fingerprint = fingerprint;
            this.message = message;
            this.pubkey = pubkey;
            this.signature = signature;
            this.address = address;
            this.signingMode = signingMode;
        }
    }
}
