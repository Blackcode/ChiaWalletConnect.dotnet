namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record SignMessageByAddressRecord
    {
        public bool Success { get; init; }
        public required string Pubkey { get; init; }
        public required string Signature { get; init; }
        public required string SigningMode { get; init; }
    }
}
