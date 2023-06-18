using WalletConnectSharp.Core.Models.Pairing;
using WalletConnectSharp.Network.Models;
using WalletConnectSharp.Sign;

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

            WalletConnectService walletConnectService = new WalletConnectService();
            await walletConnectService.Initialize(projectId, metadata);

            string topic;

            if (walletConnectService.client.Session.Keys.Length == 0)
                //if dApp is not connected create a connection. You will have the connection URI printed in the console
                topic = await walletConnectService.Connect();
            else
                //if dApp is connected use the first session as example
                topic = walletConnectService.client.Session.Values[0].Topic;

            //TODO: add more commands https://github.com/Chia-Network/chia-blockchain-gui/blob/main/packages/gui/src/constants/WalletConnectCommands.tsx

            /*//chia_getWallets
            Console.WriteLine("Accept confirmation request in Chia Application");
            var login = await walletConnectService.LogIn(fingerprint, topic);
            Console.WriteLine(login);

            //chia_getWallets
            Console.WriteLine("Accept confirmation request in Chia Application");
            var wallets = await walletConnectService.GetWallets(fingerprint, topic);
            Console.WriteLine(wallets);

            //chia_getTransaction
            Console.WriteLine("Accept confirmation request in Chia Application");
            string transactionId = "7d61d94db2ed2f210d27cc486c33bf642c72a448af8f0e00de84bef9213fd598";
            var transaction = await walletConnectService.GetTransaction(fingerprint, topic, transactionId);
            Console.WriteLine(transaction);

            //chia_getWalletBalance
            Console.WriteLine("Accept confirmation request in Chia Application");
            int walletId = 1;
            var walletbalance = await walletConnectService.GetWalletBalance(fingerprint, topic, walletId);
            Console.WriteLine(walletbalance);*/

            //chia_getCurrentAddress
            Console.WriteLine("Accept confirmation request in Chia Application");
            int walletId = 1;
            var walletbalance = await walletConnectService.GetCurrentAddress(fingerprint, topic, walletId);
            Console.WriteLine(walletbalance);
        }
    }
}