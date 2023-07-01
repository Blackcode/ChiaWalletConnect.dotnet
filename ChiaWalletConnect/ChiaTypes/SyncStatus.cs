using Newtonsoft.Json;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record SyncStatus
    {
        public bool GenesisInitialized { get; init; }
        public bool Success { get; init; }
        public bool Synced { get; init; }
        public bool Syncing { get; init; }
    }
}
