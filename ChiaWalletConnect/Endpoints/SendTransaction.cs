using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_sendTransaction")]
    internal class SendTransaction
    {
        public string fingerprint { get; set; }
        public int walletId { get; set; }
        public ulong amount { get; set; }
        public ulong fee { get; set; }
        public string address { get; set; }
        public string[]? memos { get; set; }
        public object? puzzle_decorator { get; set; }

        public SendTransaction(string fingerprint, int walletId, ulong amount, ulong fee, string address, string? memos, object? puzzle_decorator)
        {
            this.fingerprint = fingerprint;
            this.walletId = walletId;
            this.amount = amount;
            this.fee = fee;
            this.address = address;
            this.memos = new string[] { memos };
            this.puzzle_decorator = puzzle_decorator;
        }
    }
}
