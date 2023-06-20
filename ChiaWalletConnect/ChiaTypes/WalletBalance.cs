using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record WalletBalance
    {
        public ulong ConfirmedWalletBalance { get; init; }
        public ulong Fingerprint { get; init; }
        public ulong MaxSendAmount { get; init; }
        public ulong PendingChange { get; init; }
        public int PendingCoinRemovalCount { get; init; }
        public ulong SpendableBalance { get; init; }
        public ulong UnconfirmedWalletBalance { get; init; }
        public int UnspentCoinCount { get; init; }
        public int WalletId { get; init; }
        public int WalletType { get; init; }
        public ulong PendingBalance { get; init; }
        public ulong PendingTotalBalance { get; init; }
    }
}
