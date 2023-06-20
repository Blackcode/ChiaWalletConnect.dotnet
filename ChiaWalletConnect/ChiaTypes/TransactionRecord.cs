using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record TransactionRecord
    {
        public ICollection<Coin> Additions { get; init; } = new List<Coin>();
        public ulong Amount { get; init; }
        public bool Confirmed { get; init; }
        public uint ConfirmedAtHeight { get; init; }
        public double CreatedAtTime { get; init; }
        public ulong FeeAmount { get; init; }
        public object Memos { get; init; }//TODO: deserialize memos
        public string Name { get; init; } = string.Empty;
        public ICollection<Coin> Removals { get; init; } = new List<Coin>();
        public uint Sent { get; init; }
        public ICollection<SendPeer> SentTo { get; init; } = new List<SendPeer>();
        public SpendBundle? SpendBundle { get; init; }
        public string ToAddress { get; init; } = string.Empty;
        public string ToPuzzleHash { get; init; } = string.Empty;
        public string? TradeId { get; init; }
        public TransactionType Type { get; init; }
        public uint WalletId { get; init; }
    }
}
