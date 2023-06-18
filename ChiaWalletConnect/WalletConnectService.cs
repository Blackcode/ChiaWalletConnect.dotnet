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
                                "chia_getWallets",
                                "chia_getTransaction"
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

        public async Task<dynamic> GetWallets(string walletfingerprint, string topic)
        {
            var data = new GetWalletsRequest(walletfingerprint, false);
            dynamic response = await client.Request<GetWalletsRequest, dynamic>(topic, data);

            return response;
        }

        public async Task<dynamic> GetTransaction(string walletfingerprint, string transaction_id, string topic)
        {
            var data = new GetTransactionRequest(walletfingerprint, transaction_id);
            dynamic response = await client.Request<GetTransactionRequest, dynamic>(topic, data);

            return response;
        }
    }
}
