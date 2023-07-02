using ChiaWalletConnect.dotnet.ChiaTypes;
using WalletConnectSharp.Network.Models;

namespace ChiaWalletConnect.dotnet.Endpoints
{
    [RpcMethod("chia_getAllOffers")]
    internal class GetAllOffers
    {
        public string fingerprint { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public bool reverse { get; set; }
        public string sortKey { get; set; }
        public bool includeMyOffers { get; set; }
        public bool includeTakenOffers { get; set; }

        public GetAllOffers(string fingerprint, int start, int end, SortKey sortKey, bool reverse, bool includeMyOffers, bool includeTakenOffers)
        {
            this.fingerprint = fingerprint;
            this.start = start;
            this.end = end;
            this.sortKey = sortKey.ToString();
            this.reverse = reverse;
            this.includeMyOffers = includeMyOffers;
            this.includeTakenOffers = includeTakenOffers;
        }
    }
}
