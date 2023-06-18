using WalletConnectSharp.Sign.Models.Engine;
using WalletConnectSharp.Sign.Models;
using WalletConnectSharp.Sign;
using WalletConnectSharp.Core.Models.Pairing;
using Org.BouncyCastle.Asn1.Cms;
using Methods;

namespace ChiaWalletConnect.dotnet
{
    internal class WalletConnectService
    {
        public WalletConnectSignClient client;

        public async Task Initialize(string projectId, Metadata metadata)
        {
            //fix the store.json empty file bug
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var filePath = Path.Combine(home, ".wc", "store.json");
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists && fileInfo.Length == 0)
            {
                File.Delete(filePath);
            }

            SignClientOptions options = new SignClientOptions()
            {
                ProjectId = projectId,
                Metadata = metadata
            };

            client = await WalletConnectSignClient.Init(options);
        }

        public async Task<string> Connect()
        {
            ConnectedData connectData = await client.Connect(new ConnectOptions()
            {
                RequiredNamespaces = new RequiredNamespaces() {
                    { "chia",
                        new RequiredNamespace() {
                            Methods = new[] {
                                "chia_logIn",
                                "chia_getWallets",
                                "chia_getTransaction",
                                "chia_getWalletBalance",
                                /*"chia_getWalletBalances",*/
                                "chia_getCurrentAddress",
                                "chia_sendTransaction",
                                "chia_signMessageById",
                                "chia_signMessageByAddress",
                                "chia_verifySignature",
                                "chia_getNextAddress",
                                "chia_getSyncStatus",
                                "chia_getAllOffers",
                                "chia_getOffersCount",
                                "chia_createOfferForIds",
                                "chia_cancelOffer",
                                "chia_checkOfferValidity",
                                "chia_takeOffer",
                                "chia_getOfferSummary",
                                "chia_getOfferData",
                                "chia_getOfferRecord",
                                "chia_createNewCATWallet",
                                "chia_getCATWalletInfo",
                                "chia_getCATAssetId",
                                "chia_spendCAT",
                                "chia_addCATToken",
                                "chia_getNFTs",
                                "chia_getNFTInfo",
                                /*"chia_mintNFT",
                                "chia_transferNFT",
                                "chia_getNFTsCount",
                                "chia_createNewDIDWallet",
                                "chia_setDIDName",
                                "chia_setNFTDID",
                                "chia_getNFTWalletsWithDIDs",
                                /*"chia_getVCList",
                                "chia_getVC",
                                "chia_spendVC",
                                "chia_addVCProofs",
                                "chia_getProofsForRoot",
                                "chia_revokeVC",
                                "chia_showNotification"*/
                            },
                            Chains = new[] {
                                "chia:mainnet"
                            }
                        }
                    }
                }
            });

            //Show connection URI
            Console.WriteLine(connectData.Uri);
            //Await connection
            var sessionData = await connectData.Approval;

            return sessionData.Topic;
        }
        /// <summary>Log in to a wallet</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <returns>A Json object</returns>
        public async Task<dynamic> LogIn(string fingerprint, string topic)
        {
            var data = new LogInRequest(fingerprint);
            dynamic response = await client.Request<LogInRequest, dynamic>(topic, data);

            return response;
        }

        /// <summary>Requests a complete listing of the wallets associated with the current wallet key</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <param name="include_data">Include Wallet Metadata</param>
        /// <returns>A Json object</returns>
        public async Task<dynamic> GetWallets(string fingerprint, string topic, bool include_data = false)
        {
            var data = new GetWalletsRequest(fingerprint, include_data);
            dynamic response = await client.Request<GetWalletsRequest, dynamic>(topic, data);

            return response;
        }

        /// <summary>Requests details for a specific transaction</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>A Json object</returns>
        public async Task<dynamic> GetTransaction(string fingerprint, string topic, string transactionId)
        {
            var data = new GetTransactionRequest(fingerprint, transactionId);
            dynamic response = await client.Request<GetTransactionRequest, dynamic>(topic, data);

            return response;
        }

        /// <summary>Requests the asset balance for a specific wallet associated with the current wallet key</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <param name="walletId">Wallet Id</param>
        /// <returns></returns>
        public async Task<dynamic> GetWalletBalance(string fingerprint, string topic, int walletId = 1)
        {
            var data = new GetWalletBalance(fingerprint, walletId);
            dynamic response = await client.Request<GetWalletBalance, dynamic>(topic, data);

            return response;
        }

        /// <summary>>Requests the current receive address associated with the current wallet key</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <param name="walletId">Wallet Id</param>
        /// <returns></returns>
        public async Task<dynamic> GetCurrentAddress(string fingerprint, string topic, int walletId = 1)
        {
            var data = new GetCurrentAddress(fingerprint, walletId);
            dynamic response = await client.Request<GetCurrentAddress, dynamic>(topic, data);

            return response;
        }
    }
}
