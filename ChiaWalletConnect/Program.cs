using ChiaWalletConnect.dotnet.ChiaTypes;
using WalletConnectSharp.Core.Models.Pairing;

namespace ChiaWalletConnect.dotnet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //chia wallet id
            string fingerprint = "1921498453";
            //create a project id at https://cloud.walletconnect.com/app
            string projectId = "a97dbb2756d03b9160843f6ec3ecb989";
            //dApp metadata
            Metadata metadata = new Metadata()
            {
                Description = "Chia Connect dApp",
                Icons = new[] { "https://s2.coinmarketcap.com/static/img/coins/200x200/9258.png" },
                Name = "ChiaConnect",
                Url = "https://chia.org/",
            };

            WalletConnect walletConnect = new WalletConnect();
            await walletConnect.Initialize(projectId, metadata);

            string topic;

            if (walletConnect.client.Session.Keys.Length == 0)
                //if dApp is not connected create a connection. You will have the connection URI printed in the console
                topic = await walletConnect.Connect();
            else
                //if dApp is connected use the first session as example
                topic = walletConnect.client.Session.Values[0].Topic;

            //TODO: add more commands https://github.com/Chia-Network/chia-blockchain-gui/blob/main/packages/gui/src/constants/WalletConnectCommands.tsx
            //TODO: Add Events to permit multiple commands
            //TODO: Add a wait for sync function if needed

            /*
            //chia_logIn
            Console.WriteLine("Accept confirmation request in Chia Application");
            LoginResult chia_logIn = await walletConnect.LogIn(fingerprint, topic);
            Console.WriteLine(chia_logIn);

            //chia_getWallets
            Console.WriteLine("Accept confirmation request in Chia Application");
            IEnumerable<WalletInfo> chia_getWallets = await walletConnect.GetWallets(fingerprint, topic);
            Console.WriteLine(chia_getWallets);

            //chia_getTransaction
            Console.WriteLine("Accept confirmation request in Chia Application");
            TransactionRecord chia_getTransaction = await walletConnect.GetTransaction(fingerprint, topic, "7d61d94db2ed2f210d27cc486c33bf642c72a448af8f0e00de84bef9213fd598");
            Console.WriteLine(chia_getTransaction);

            //chia_getWalletBalance
            Console.WriteLine("Accept confirmation request in Chia Application");
            WalletBalance chia_getWalletBalance = await walletConnect.GetWalletBalance(fingerprint, topic, 1);
            Console.WriteLine(chia_getWalletBalance);

            //chia_getWalletBalances
            Console.WriteLine("Accept confirmation request in Chia Application");
            Dictionary<string, WalletBalance> chia_getWalletBalances = await walletConnect.GetWalletBalances(fingerprint, topic);
            Console.WriteLine(chia_getWalletBalances);

            //chia_getCurrentAddress
            Console.WriteLine("Accept confirmation request in Chia Application");
            string chia_getCurrentAddress = await walletConnect.GetCurrentAddress(fingerprint, topic, 1);
            Console.WriteLine(chia_getCurrentAddress); 

            //chia_getNextAddress
            Console.WriteLine("Accept confirmation request in Chia Application");
            string chia_getNextAddress = await walletConnect.GetNextAddress(fingerprint, topic, 1, true);
            Console.WriteLine(chia_getNextAddress);

            //chia_sendTransaction
            Console.WriteLine("Accept confirmation request in Chia Application");
            SendTransactionRecord chia_sendTransaction = await walletConnect.SendTransaction(fingerprint, topic, 1, 1, 0, "xch1ndw4800z234plztr4q02yz9x76fh5yset958ydf3239y4x2gyynsrx3uqf", "memo");
            Console.WriteLine(chia_sendTransaction);

            //chia_signMessageById
            Console.WriteLine("Accept confirmation request in Chia Application");
            SignMessageByIdRecord chia_signMessageById = await walletConnect.SignMessageById(fingerprint, topic, "did:chia:1y3sf537w3efyd3xqxfeat6ul75ex4fzcvg7ey2ntth74lwe6ymcqkmp3vz", "test");
            Console.WriteLine(chia_signMessageById);

            //chia_signMessageByAddress
            Console.WriteLine("Accept confirmation request in Chia Application");
            SignMessageByAddressRecord chia_signMessageByAddress = await walletConnect.SignMessageByAddress(fingerprint, topic, "xch1ndw4800z234plztr4q02yz9x76fh5yset958ydf3239y4x2gyynsrx3uqf", "test");
            Console.WriteLine(chia_signMessageByAddress);

            //chia_verifySignature
            Console.WriteLine("Accept confirmation request in Chia Application");
            bool chia_verifySignature = await walletConnect.VerifySignature(fingerprint, topic, "test", "a385c0bf16c78b6905f559739a4b51dd6a4eeccc482913f362539e080e5bdcfb039a0feb9cf5d28279c8d4fd49699b73", "a20e52dbdcd51d41a7a41ab3847a5348ab6f754122c6e61d87ac614feb9eec5cfd96e2e81083078e7a112290e631e7560c0de34305791657c476df6c7f1278dc8491a7ae09076c257d4fd1b053af862e66e443619ac18a3cf13e6baa62310617");
            Console.WriteLine(chia_verifySignature);

            //chia_getSyncStatus
            Console.WriteLine("Accept confirmation request in Chia Application");
            var chia_getSyncStatus = await walletConnect.GetSyncStatus(fingerprint, topic);
            Console.WriteLine(chia_getSyncStatus);
            
            //chia_getAllOffers - Waiting for fix to be done https://github.com/WalletConnect/WalletConnectSharp/pull/104
            Console.WriteLine("Accept confirmation request in Chia Application");
            var chia_getAllOffers = await walletConnect.GetAllOffers(fingerprint, topic, 0, 10, SortKey.CONFIRMED_AT_HEIGHT, false, true, true);
            Console.WriteLine(chia_getAllOffers);
            
            //chia_getOffersCount
            Console.WriteLine("Accept confirmation request in Chia Application");
            var chia_getOffersCount = await walletConnect.GetOffersCount(fingerprint, topic);
            Console.WriteLine(chia_getOffersCount);
            */
        }
    }
}