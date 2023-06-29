using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record ClawbackRecord
    {
        public bool Success { get; init; }
        public required string[] transactionIds { get; init; }
    }
}
