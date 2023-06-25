using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record WalletBalancesRecord
    {
        public bool Success { get; init; }
        public required Dictionary<string, WalletBalance> WalletBalances { get; init; }
    }
}
