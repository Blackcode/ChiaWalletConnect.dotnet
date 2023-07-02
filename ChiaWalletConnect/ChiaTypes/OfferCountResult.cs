using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record OfferCountResult
    {
        public ulong MyOffersCount { get; init; }
        public ulong TakenOffersCount { get; init; }
        public ulong Total { get; init; }
        public bool Success { get; init; }
    }
}
