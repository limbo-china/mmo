using System;
using System.IO;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fi = new System.IO.FileInfo("../../Log/log4net.xml");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(fi);
            Log.Init("GameServer");
            Log.Info("Game Server Init");

            GameServer server = new GameServer();
            server.Init();
            server.Start();
            Console.WriteLine("Game Server Running......");

            while (true)
            {
                System.Threading.Thread.Sleep(1000);
            }
            //Log.Info("Game Server Exiting...");
            //server.Stop();
            //Log.Info("Game Server Exited");
        }
    }
}
