using UnityEngine;
using Message;
using Net;
using UnityEngine.Events;

namespace Service
{
    public class LoginService:MonoSingleton<LoginService>
    {
        public UnityAction<Result, string> OnLogin;
        void Start()
        {
            MessageDistributer.Instance.Subscribe<UserLoginResponse>(this.OnLoginResponse);
        }
        public void Login(string user, string psw)
        {
            Debug.LogFormat("UserLoginRequest::user :{0} psw:{1}", user, psw);
            NetMessage message = new NetMessage();
            message.Request = new NetMessageRequest();
            message.Request.userLogin = new UserLoginRequest();
            message.Request.userLogin.User = user;
            message.Request.userLogin.Passward = psw;

            if (!NetClient.Instance.Connected)
            {
                NetClient.Instance.ConnectToServer();
            }
            NetClient.Instance.SendMessage(message);
           
        }
        void OnLoginResponse(object sender, UserLoginResponse response)
        {
            this.OnLogin(response.Result, response.Errormsg);
        }

    }
}
