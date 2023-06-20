using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record LoginResult
    {
        public ulong Fingerprint { get; init; }
        public bool Success { get; init; }
    }
}
