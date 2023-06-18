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
                                "chia_getWalletBalance"
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
        /// <summary>Log In</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Client Topic</param>
        /// <returns>A Json object</returns>
        public async Task<dynamic> LogIn(string fingerprint, string topic)
        {
            var data = new LogInRequest(fingerprint);
            dynamic response = await client.Request<LogInRequest, dynamic>(topic, data);

            return response;
        }

        /// <summary>Get wallets</summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Client Topic</param>
        /// <returns>A Json object</returns>
        public async Task<dynamic> GetWallets(string fingerprint, string topic)
        {
            var data = new GetWalletsRequest(fingerprint, false);
            dynamic response = await client.Request<GetWalletsRequest, dynamic>(topic, data);

            return response;
        }

        /// <summary></summary>
        /// <param name="fingerprint">Fingerprint</param>
        /// <param name="topic">Client Topic</param>
        /// <param name="transactionId">The transaction id</param>
        /// <returns></returns>
        public async Task<dynamic> GetTransaction(string fingerprint, string topic, string transactionId)
        {
            var data = new GetTransactionRequest(fingerprint, transactionId);
            dynamic response = await client.Request<GetTransactionRequest, dynamic>(topic, data);

            return response;
        }

        public async Task<dynamic> GetWalletBalance(string fingerprint, string topic, int walletId = 1)
        {
            var data = new GetWalletBalance(fingerprint, walletId);
            dynamic response = await client.Request<GetWalletBalance, dynamic>(topic, data);

            return response;
        }
    }
}
