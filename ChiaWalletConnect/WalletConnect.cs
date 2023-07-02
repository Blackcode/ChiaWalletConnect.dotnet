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
                                "chia_logIn",//Done v2.
                                "chia_getWallets",//Done v2.
                                "chia_getTransaction",//Done v2.
                                "chia_getWalletBalance",//Done v2.
                                "chia_getWalletBalances",//Done v2.
                                "chia_getCurrentAddress",//Done v2.
                                "chia_sendTransaction",//Done v2.
                                "chia_signMessageById",//Done v2.
                                "chia_signMessageByAddress",//Done v2.
                                "chia_verifySignature",//Done v2.
                                "chia_getNextAddress",//Done v2.
                                "chia_getSyncStatus",//Done v2.
                                "chia_getAllOffers",//Done v2. Waiting for fix to be done https://github.com/WalletConnect/WalletConnectSharp/pull/104
                                "chia_getOffersCount",//Done v2.
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

        #region chia_logIn
        /// <summary>Logs in to a wallet key (account), as identified by its fingerprint.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <returns>The output is a value of type LoginResult.</returns>
        public async Task<LoginResult> LogIn(string fingerprint, string topic)
        {
            LogIn data = new LogIn(fingerprint);
            dynamic response = await client.Request<LogIn, dynamic>(topic, data);

            return Converters.ToObject<LoginResult>(response, "data");
        }
        #endregion

        #region chia_getWallets
        /// <summary>Requests a complete listing of the wallets associated with the current wallet key.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <param name="include_data">Whether to include metadata.</param>
        /// <returns>The output is a list of <see cref="WalletInfo"/>s.</returns>
        public async Task<IEnumerable<WalletInfo>> GetWallets(string fingerprint, string topic, bool include_data = false)
        {
            GetWallets data = new GetWallets(fingerprint, include_data);
            dynamic response = await client.Request<GetWallets, dynamic>(topic, data);

            return Converters.ToObject<IEnumerable<WalletInfo>>(response, "data");
        }
        #endregion

        #region chia_getTransaction
        /// <summary>Gets a transaction record by its id.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <param name="transactionId">Transaction id.</param>
        /// <returns>The output is a value of type <see cref="TransactionRecord"/>.</returns>
        public async Task<TransactionRecord> GetTransaction(string fingerprint, string topic, string transactionId)
        {
            GetTransaction data = new GetTransaction(fingerprint, transactionId);
            dynamic response = await client.Request<GetTransaction, dynamic>(topic, data);

            return Converters.ToObject<TransactionRecord>(response, "data");
        }
        #endregion

        #region chia_getWalletBalance
        /// <summary>Requests the asset balance for a specific wallet associated with the current wallet key.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <param name="walletId">Wallet id to get the balance of.</param>
        /// <returns>The output is a value of type <see cref="WalletBalance"/>.</returns>
        public async Task<WalletBalance> GetWalletBalance(string fingerprint, string topic, int walletId = 1)
        {
            GetWalletBalance data = new GetWalletBalance(fingerprint, walletId);
            dynamic response = await client.Request<GetWalletBalance, dynamic>(topic, data);

            return Converters.ToObject<WalletBalance>(response, "data");
        }
        #endregion

        #region chia_getWalletBalances
        /// <summary>Requests the asset balances for specific wallets associated with the current wallet key.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <param name="walletIds">Wallet ids to get the balance of.</param>
        /// <returns>The output is a list of <see cref="WalletBalance"/>s.</returns>
        public async Task<Dictionary<string, WalletBalance>> GetWalletBalances(string fingerprint, string topic, int[]? walletIds = null)
        {
            GetWalletBalances data = new GetWalletBalances(fingerprint, walletIds);
            dynamic response = await client.Request<GetWalletBalances, dynamic>(topic, data);

            return Converters.ToObject<Dictionary<string, WalletBalance>>(response.data, "walletBalances");
        }
        #endregion

        #region chia_getCurrentAddress
        /// <summary>Gets the address of the current derivation index.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <param name="walletId">Wallet id to get the address of.</param>
        /// <returns>The output is a bech32m encoded address of type string.</returns>
        public async Task<string> GetCurrentAddress(string fingerprint, string topic, int walletId = 1)
        {
            GetCurrentAddress data = new GetCurrentAddress(fingerprint, walletId);
            dynamic response = await client.Request<GetCurrentAddress, dynamic>(topic, data);

            return Converters.ToObject<string>(response, "data");
        }
        #endregion

        #region chia_getNextAddress
        /// <summary>>Gets the address of the next derivation index associated with the current wallet key.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <param name="walletId">Wallet id to get the address of.</param>
        /// <param name="newAddress">Whether to increase derivation index.</param>
        /// <returns>The output is a bech32m encoded address of type string.</returns>
        public async Task<string> GetNextAddress(string fingerprint, string topic, int walletId = 1, bool newAddress = true)
        {
            GetNextAddress data = new GetNextAddress(fingerprint, walletId, newAddress);
            dynamic response = await client.Request<GetNextAddress, dynamic>(topic, data);

            return Converters.ToObject<string>(response, "data");
        }
        #endregion

        #region chia_sendTransaction
        /// <summary>Sends an amount of mojos in a given standard wallet to a recipient address.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <param name="walletId">Wallet id to use coins from.</param>
        /// <param name="amount">Amount in mojos.</param>
        /// <param name="fee">Transaction fee in mojos.</param>
        /// <param name="address">Bech32m encoded recipient address.</param>
        /// <param name="memos">A memo that helps the receiver side to identify the payment.</param>
        /// <param name="puzzle_decorator">A inner puzzle decorator</param>
        /// <returns>The output is a value of type <see cref="SendTransactionRecord"/>.</returns>
        public async Task<SendTransactionRecord> SendTransaction(string fingerprint, string topic, int walletId, ulong amount, ulong fee, string address, string? memo = null, object? puzzle_decorator = null)
        {
            string[]? memos = null;
            if (memo != null)
                memos = new string[] { memo };

            SendTransaction data = new SendTransaction(fingerprint, walletId, amount, fee, address, memos, puzzle_decorator);
            dynamic response = await client.Request<SendTransaction, dynamic>(topic, data);

            return Converters.ToObject<SendTransactionRecord>(response, "data");
        }
        #endregion

        #region chia_signMessageById
        /// <summary>Signs a message with the private key of a given DID.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <param name="id">DID to sign the message with the key of.</param>
        /// <param name="message">Message to sign.</param>
        /// <returns>The output is a value of type <see cref="SignMessageByIdRecord"/>.</returns>
        public async Task<SignMessageByIdRecord> SignMessageById(string fingerprint, string topic, string id, string message)
        {
            SignMessageById data = new SignMessageById(fingerprint, id, message);
            dynamic response = await client.Request<SignMessageById, dynamic>(topic, data);

            return Converters.ToObject<SignMessageByIdRecord>(response, "data");
        }
        #endregion

        #region chia_signMessageByAddress
        /// <summary>Signs a message with the private key of a given address.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <param name="address">Address to sign the message with the key of.</param>
        /// <param name="message">Message to sign.</param>
        /// <returns>The output is a value of type <see cref="SignMessageByAddressRecord"/>.</returns>
        public async Task<SignMessageByAddressRecord> SignMessageByAddress(string fingerprint, string topic, string address, string message)
        {
            SignMessageByAddress data = new SignMessageByAddress(fingerprint, address, message);
            dynamic response = await client.Request<SignMessageByAddress, dynamic>(topic, data);

            return Converters.ToObject<SignMessageByAddressRecord>(response, "data");
        }
        #endregion

        #region chia_verifySignature
        /// <summary>Verifies a signature over a message from a given public key.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <param name="message">Message to verify.</param>
        /// <param name="pubkey">Hex encoded public key.</param>
        /// <param name="signature">Hex encoded BLS12-381 signature.</param>
        /// <param name="address">Address used for signing.</param>
        /// <param name="signingMode">Signing mode used.</param>
        /// <returns>The output is a value of type <see cref="bool"/>.</returns>
        public async Task<bool> VerifySignature(string fingerprint, string topic, string message, string pubkey, string signature, string? address = null, string? signingMode = "BLS_SIG_BLS12381G2_XMD:SHA-256_SSWU_RO_AUG:CHIP-0002_")
        {
            VerifySignature data = new VerifySignature(fingerprint, message, pubkey, signature, address, signingMode);
            dynamic response = await client.Request<VerifySignature, dynamic>(topic, data);

            return Converters.ToObject<bool>(response.data, "isValid");
        }
        #endregion

        #region chia_getSyncStatus
        /// <summary>Requests the syncing status of current wallet.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <returns>The output is a value of type <see cref="SyncStatus"/>.</returns>
        public async Task<SyncStatus> GetSyncStatus(string fingerprint, string topic)
        {
            GetSyncStatus data = new GetSyncStatus(fingerprint);
            dynamic response = await client.Request<GetSyncStatus, dynamic>(topic, data);

            return Converters.ToObject<SyncStatus>(response, "data");
        }
        #endregion

        #region chia_getAllOffers
        /// <summary>>Requests a complete listing of the offers associated with the current wallet key.</summary>
        /// <param name="fingerprint"></param>
        /// <param name="topic"></param>
        /// <returns></returns>
        public async Task<object> GetAllOffers(string fingerprint, string topic, int start = 0, int end = 10, SortKey sortKey = SortKey.CONFIRMED_AT_HEIGHT, bool reverse = true, bool includeMyOffers = true, bool includeTakenOffers = true)
        {
            GetAllOffers data = new GetAllOffers(fingerprint, start, end, sortKey, reverse, includeMyOffers, includeTakenOffers);
            dynamic response = await client.Request<GetAllOffers, dynamic>(topic, data);

            return Converters.ToObject<object>(response, "data");
        }
        #endregion

        #region chia_getOffersCount
        /// <summary>Requests the number of offers associated with the current wallet key.</summary>
        /// <param name="fingerprint">Chia wallet fingerprint.</param>
        /// <param name="topic">Wallet connect pairing topic.</param>
        /// <returns>The output is a value of type <see cref="OfferCountResult"/>.</returns>
        public async Task<OfferCountResult> GetOffersCount(string fingerprint, string topic)
        {
            GetOffersCount data = new GetOffersCount(fingerprint);
            dynamic response = await client.Request<GetOffersCount, dynamic>(topic, data);

            return Converters.ToObject<OfferCountResult>(response, "data");
        }
        #endregion
    }
}
