using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record CoinSpend
    {
        public Coin Coin { get; init; } = new();
        public string PuzzleReveal { get; init; } = string.Empty;
        public string Solution { get; init; } = string.Empty;
    }
}
