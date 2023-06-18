using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletConnectSharp.Network.Models;

namespace Methods
{
    [RpcMethod("chia_getWallets")]
    public class GetWalletsRequest
    {
        public string fingerprint { get; set; }
        public bool includeData { get; set; }
        public GetWalletsRequest(string fingerprint, bool includeData)
        {
            this.fingerprint = fingerprint;
            this.includeData = includeData;
        }
    }

    [RpcMethod("chia_getTransaction")]
    public class GetTransactionRequest
    {
        public string fingerprint { get; set; }
        public string transactionId { get; set; }
        public GetTransactionRequest(string fingerprint, string transaction_id)
        {
            this.fingerprint = fingerprint;
            transactionId = transaction_id;
        }
    }
}
