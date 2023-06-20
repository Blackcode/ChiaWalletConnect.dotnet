using WalletConnectSharp.Sign.Models.Engine;
using WalletConnectSharp.Sign.Models;
using WalletConnectSharp.Sign;
using WalletConnectSharp.Core.Models.Pairing;
using Org.BouncyCastle.Asn1.Cms;
using ChiaWalletConnect.dotnet.Endpoints;
using ChiaWalletConnect.dotnet.ChiaTypes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using ChiaWalletConnect.dotnet.Utils;

namespace ChiaWalletConnect.dotnet
{
    internal class WalletConnect
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
                                "chia_logIn",//done
                                "chia_getWallets",//done
                                "chia_getTransaction",//done
                                "chia_getWalletBalance",//done
                                /*"chia_getWalletBalances",*///1.8.2
                                "chia_getCurrentAddress",//done
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
                                /*"chia_mintNFT",//1.8.2
                                "chia_transferNFT",//1.8.2
                                "chia_getNFTsCount",//1.8.2
                                "chia_createNewDIDWallet",//1.8.2
                                "chia_setDIDName",//1.8.2
                                "chia_setNFTDID",//1.8.2
                                "chia_getNFTWalletsWithDIDs",//1.8.2
                                "chia_getVCList",//1.8.2
                                "chia_getVC",//1.8.2
                                "chia_spendVC",//1.8.2
                                "chia_addVCProofs",//1.8.2
                                "chia_getProofsForRoot",//1.8.2
                                "chia_revokeVC",//1.8.2
                                "chia_showNotification"*///1.8.2
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
        public async Task<LoginResult> LogIn(string fingerprint, string topic)
        {
            var data = new LogIn(fingerprint);
            dynamic response = await client.Request<LogIn, dynamic>(topic, data);

            return Converters.ToObject<LoginResult>(response, "data");
        }

        /// <summary>Requests a complete listing of the wallets associated with the current wallet key</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <param name="include_data">Include Wallet Metadata</param>
        /// <returns>A Json object</returns>
        public async Task<IEnumerable<WalletInfo>> GetWallets(string fingerprint, string topic, bool include_data = false)
        {
            var data = new GetWallets(fingerprint, include_data);
            dynamic response = await client.Request<GetWallets, dynamic>(topic, data);

            return Converters.ToObject<IEnumerable<WalletInfo>>(response, "data");
        }

        /// <summary>Requests details for a specific transaction</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>A Json object</returns>
        public async Task<TransactionRecord> GetTransaction(string fingerprint, string topic, string transactionId)
        {
            var data = new GetTransaction(fingerprint, transactionId);
            dynamic response = await client.Request<GetTransaction, dynamic>(topic, data);

            return Converters.ToObject<TransactionRecord>(response, "data");
        }

        /// <summary>Requests the asset balance for a specific wallet associated with the current wallet key</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <param name="walletId">Wallet Id</param>
        /// <returns>WalletBalance</returns>
        public async Task<WalletBalance> GetWalletBalance(string fingerprint, string topic, int walletId = 1)
        {
            var data = new GetWalletBalance(fingerprint, walletId);
            dynamic response = await client.Request<GetWalletBalance, dynamic>(topic, data);

            return Converters.ToObject<WalletBalance>(response, "data");
        }

        /// <summary>>Requests the current receive address associated with the current wallet key</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <param name="walletId">Wallet Id</param>
        /// <returns>string</returns>
        public async Task<string> GetCurrentAddress(string fingerprint, string topic, int walletId = 1)
        {
            var data = new GetCurrentAddress(fingerprint, walletId);
            dynamic response = await client.Request<GetCurrentAddress, dynamic>(topic, data);

            return Converters.ToObject<string>(response, "data");
        }
    }
}
