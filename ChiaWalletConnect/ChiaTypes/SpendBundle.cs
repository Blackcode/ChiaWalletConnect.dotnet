using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record SpendBundle
    {
        public string AggregatedSignature { get; init; } = string.Empty;
        public ICollection<CoinSpend> CoinSpends { get; init; } = new List<CoinSpend>();
    }
}
