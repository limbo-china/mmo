using System.Threading;

using Net;
using Service;

namespace GameServer
{
    class GameServer
    {
        NetService network;
        Thread thread;
        bool running = false;
        public bool Init()
        {
            int Port = Configuration.Settings.Default.ServerPort;
            network = new NetService();
            network.Init(Port);
            RegisterService.Instance.Init();
            LoginService.Instance.Init();
            DBService.Instance.Init();
            thread = new Thread(new ThreadStart(this.Update));

            return true;
        }

        public void Start()
        {
            network.Start();
            running = true;
            thread.Start();
        }


        public void Stop()
        {
            running = false;
            thread.Join();
            network.Stop();
        }

        public void Update()
        {
            //var mapManager = MapManager.Instance;
            //while (running)
            //{
            //    Time.Tick();
            //    Thread.Sleep(100);
            //    //Console.WriteLine("{0} {1} {2} {3} {4}", Time.deltaTime, Time.frameCount, Time.ticks, Time.time, Time.realtimeSinceStartup);
            //    mapManager.Update();
            //}
        }
    }
}
