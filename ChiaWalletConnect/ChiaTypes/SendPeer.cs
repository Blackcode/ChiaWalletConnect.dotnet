using Newtonsoft.Json;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    [JsonConverter(typeof(SendPeerConverter))]
    public record SendPeer
    {
        public string Peer { get; init; } = string.Empty;
        public MempoolInclusionStatus MempoolInclusionStatus { get; init; }
        public string? ErrorMessage { get; init; }
    }
}
