using WalletConnectSharp.Sign.Models.Engine;
using WalletConnectSharp.Sign.Models;
using WalletConnectSharp.Sign;
using WalletConnectSharp.Core.Models.Pairing;
using ChiaWalletConnect.dotnet.Endpoints;
using ChiaWalletConnect.dotnet.ChiaTypes;
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
                                "chia_getWalletBalances",//done
                                "chia_getCurrentAddress",//done
                                "chia_sendTransaction",//done
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
                                "chia_mintNFT",
                                "chia_transferNFT",
                                "chia_getNFTsCount",
                                "chia_createNewDIDWallet",
                                "chia_setDIDName",
                                "chia_setNFTDID",
                                "chia_getNFTWalletsWithDIDs",
                                "chia_getVCList",
                                "chia_getVC",
                                "chia_spendVC",
                                "chia_addVCProofs",
                                "chia_getProofsForRoot",
                                "chia_revokeVC",
                                "chia_showNotification"
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

        /// <summary>Requests the asset balances for specific wallets associated with the current wallet key</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <param name="walletId">Wallet Ids</param>
        /// <returns>WalletBalances</returns>
        public async Task<WalletBalancesRecord> GetWalletBalances(string fingerprint, string topic, int[]? walletIds = null)
        {
            var data = new GetWalletBalances(fingerprint, walletIds);
            dynamic response = await client.Request<GetWalletBalances, dynamic>(topic, data);

            return Converters.ToObject<WalletBalancesRecord>(response, "data");
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

        /// <summary>Send a transaction to a standard wallet</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Topic</param>
        /// <param name="walletId">Wallet Id</param>
        /// <param name="amount">Amount</param>
        /// <param name="fees">Fee</param>
        /// <param name="address">Address</param>
        /// <param name="memos">Memos</param>
        /// <param name="puzzle_decorator">Puzzle Decorator</param>
        /// <returns></returns>
        public async Task<SendTransactionRecord> SendTransaction(string fingerprint, string topic, int walletId, ulong amount, ulong fee, string address, string? memos = null, object? puzzle_decorator = null)
        {
            var data = new SendTransaction(fingerprint, walletId, amount, fee, address, memos, puzzle_decorator);
            dynamic response = await client.Request<SendTransaction, dynamic>(topic, data);

            return Converters.ToObject<SendTransactionRecord>(response, "data");
        }
    }
}
