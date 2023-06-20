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
            
            //chia_logIn
            /*Console.WriteLine("Accept confirmation request in Chia Application");
            var login = await walletConnect.LogIn(fingerprint, topic);
            Console.WriteLine(login);

            //chia_getWallets
            Console.WriteLine("Accept confirmation request in Chia Application");
            var wallets = await walletConnect.GetWallets(fingerprint, topic);
            Console.WriteLine(wallets);

            //chia_getTransaction
            Console.WriteLine("Accept confirmation request in Chia Application");
            var transaction = await walletConnect.GetTransaction(fingerprint, topic, "7d61d94db2ed2f210d27cc486c33bf642c72a448af8f0e00de84bef9213fd598");
            Console.WriteLine(transaction);

            //chia_getWalletBalance
            Console.WriteLine("Accept confirmation request in Chia Application");
            var walletbalance = await walletConnect.GetWalletBalance(fingerprint, topic, 1);
            Console.WriteLine(walletbalance);

            //chia_getCurrentAddress
            Console.WriteLine("Accept confirmation request in Chia Application");
            var currentaddress = await walletConnect.GetCurrentAddress(fingerprint, topic, 1);
            Console.WriteLine(walletbalance);*/
        }
    }
}