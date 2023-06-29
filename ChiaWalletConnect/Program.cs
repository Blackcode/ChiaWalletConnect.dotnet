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

            //chia_logIn
            /* Console.WriteLine("Accept confirmation request in Chia Application");
            var login = await walletConnect.LogIn(fingerprint, topic);
            Console.WriteLine(login); */

            //chia_getWallets
            /* Console.WriteLine("Accept confirmation request in Chia Application");
            var wallets = await walletConnect.GetWallets(fingerprint, topic);
            Console.WriteLine(wallets); */

            //chia_getTransaction
            /* Console.WriteLine("Accept confirmation request in Chia Application");
            var transaction = await walletConnect.GetTransaction(fingerprint, topic, "7d61d94db2ed2f210d27cc486c33bf642c72a448af8f0e00de84bef9213fd598");
            Console.WriteLine(transaction); */

            //chia_getWalletBalance
            /* Console.WriteLine("Accept confirmation request in Chia Application");
            var walletbalance = await walletConnect.GetWalletBalance(fingerprint, topic, 1);
            Console.WriteLine(walletbalance); */

            //chia_getWalletBalances
            /* Console.WriteLine("Accept confirmation request in Chia Application");
            var walletbalances = await walletConnect.GetWalletBalances(fingerprint, topic);
            Console.WriteLine(walletbalances); */

            //chia_getCurrentAddress
            /* Console.WriteLine("Accept confirmation request in Chia Application");
            var currentaddress = await walletConnect.GetCurrentAddress(fingerprint, topic, 1);
            Console.WriteLine(currentaddress); */

            //chia_SendTransaction
            /* Console.WriteLine("Accept confirmation request in Chia Application");
            var sendtransaction = await walletConnect.SendTransaction(fingerprint, topic, 1, 1, 0, "xch1ndw4800z234plztr4q02yz9x76fh5yset958ydf3239y4x2gyynsrx3uqf", "memo");
            Console.WriteLine(sendtransaction); */

            //Wallet connection is not yet implemented in Chia client 1.8.2
            //chia_SpendClawbackCoins 
            /* Console.WriteLine("Accept confirmation request in Chia Application");
            var spendClawbackCoins = await walletConnect.SpendClawbackCoins(fingerprint, topic, 1, new string[] { "aee3c32c8af74e6a2ca35f4d2abe30e7207cb97ba1270bfb4ace13d3aec0dfdf" }, 0);
            Console.WriteLine(spendClawbackCoins); */

            //chia_SignMessageById
            /*Console.WriteLine("Accept confirmation request in Chia Application");
            var signMessageById = await walletConnect.SignMessageById(fingerprint, topic, "did:chia:1y3sf537w3efyd3xqxfeat6ul75ex4fzcvg7ey2ntth74lwe6ymcqkmp3vz", "test");
            Console.WriteLine(signMessageById); */

            //chia_SignMessageByAddress
            /*Console.WriteLine("Accept confirmation request in Chia Application");
            var signMessageByAddress = await walletConnect.SignMessageByAddress(fingerprint, topic, "xch1ndw4800z234plztr4q02yz9x76fh5yset958ydf3239y4x2gyynsrx3uqf", "test");
            Console.WriteLine(signMessageByAddress); */
        }
    }
}