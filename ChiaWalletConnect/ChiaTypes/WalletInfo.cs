using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public record WalletInfo
    {
        public uint Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public WalletType Type { get; init; }
        public string Data { get; init; } = string.Empty;
    }
}
