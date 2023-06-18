using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletConnectSharp.Network.Models;

namespace Methods
{
    [RpcMethod("chia_logIn")]
    public class LogInRequest
    {
        public string fingerprint { get; set; }
        public LogInRequest(string fingerprint)
        {
            this.fingerprint = fingerprint;
        }
    }

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
        public GetTransactionRequest(string fingerprint, string transactionId)
        {
            this.fingerprint = fingerprint;
            this.transactionId = transactionId;
        }
    }

    [RpcMethod("chia_getWalletBalance")]
    public class GetWalletBalance
    {
        public string fingerprint { get; set; }
        public int walletId { get; set; }
        public GetWalletBalance(string fingerprint, int walletId)
        {
            this.fingerprint = fingerprint;
            this.walletId = walletId;
        }
    }
}
