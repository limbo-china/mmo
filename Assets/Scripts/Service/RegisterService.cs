using Message;
using Net;
using UnityEngine;
using UnityEngine.Events;

namespace Service
{
    public class RegisterService: MonoSingleton<RegisterService>
    {
        public UnityAction<Result, string> OnRegister;
        void Start()
        {
            MessageDistributer.Instance.Subscribe<UserRegisterResponse>(this.OnRegisterResponse);
        }

        public void Register(string user, string psw)
        {
            Debug.LogFormat("UserRegisterRequest::user :{0} psw:{1}", user, psw);
            NetMessage message = new NetMessage();
            message.Request = new NetMessageRequest();
            message.Request.userRegister = new UserRegisterRequest();
            message.Request.userRegister.User = user;
            message.Request.userRegister.Passward = psw;

            if (!NetClient.Instance.Connected)
            {
                NetClient.Instance.ConnectToServer();
            }
            NetClient.Instance.SendMessage(message);
        }

        public void OnRegisterResponse(object sender, UserRegisterResponse response)
        {
            this.OnRegister(response.Result, response.Errormsg);
        }
    }
}
