using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMORPGServer.Entity;
using GameServer;
using Message;

namespace Net
{
    class NetSession : INetSession
    {
        public IPostResponser PostResponser { get; set; }

        public void Disconnected()
        {
            this.PostResponser = null;
        }


        NetMessage response;

        public NetMessageResponse Response
        {
            get
            {
                if (response == null)
                {
                    response = new NetMessage();
                }
                if (response.Response == null)
                    response.Response = new NetMessageResponse();
                return response.Response;
            }
        }

        public byte[] GetResponse()
        {
            if (response != null)
            {
                if (PostResponser != null)
                    this.PostResponser.PostProcess(Response);

                byte[] data = PackageHandler.PackMessage(response);
                response = null;
                return data;
            }
            return null;
        }
    }
}
