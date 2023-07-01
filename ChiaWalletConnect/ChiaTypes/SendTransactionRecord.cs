using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record SendTransactionRecord
    {
        public bool Success { get; init; }
        public required string TransactionId { get; init; }
        public required TransactionRecord Transaction { get; init; }
    }
}
