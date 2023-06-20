using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiaWalletConnect.dotnet.ChiaTypes
{
    public enum MempoolInclusionStatus : byte
    {
        /// <summary>
        /// Transaction added to mempool
        /// </summary>
        SUCCESS = 1,
        /// <summary>
        /// Transaction not yet added to mempool
        /// </summary>
        PENDING = 2,
        /// <summary>
        /// Transaction was invalid and dropped
        /// </summary>
        FAILED = 3
    }
}
