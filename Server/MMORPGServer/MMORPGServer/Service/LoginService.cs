using System.Linq;
using Net;
using Message;
using MMORPGServer.Entity;

namespace Service
{
    public class LoginService : Singleton<LoginService>
    {

        public LoginService()
        {
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<UserLoginRequest>(this.OnLogin);
        }
        public void Init()
        {

        }

        void OnLogin(NetConnection<NetSession> sender, UserLoginRequest request)
        {
            Log.InfoFormat("UserLoginRequest: User:{0}  Pass:{1}", request.User, request.Passward);

            sender.Session.Response.userLogin = new UserLoginResponse();

            tuser user = DBService.Instance.Entities.tuser.Where(u => u.UserName == request.User).FirstOrDefault();
            if (user == null)
            {
                sender.Session.Response.userLogin.Result = Result.Failed;
                sender.Session.Response.userLogin.Errormsg = "用户不存在";
            }
            else if (user.Password != request.Passward)
            {
                sender.Session.Response.userLogin.Result = Result.Failed;
                sender.Session.Response.userLogin.Errormsg = "密码错误";
            }
            else
            {
                //sender.Session.User = user;

                sender.Session.Response.userLogin.Result = Result.Success;
                sender.Session.Response.userLogin.Errormsg = "None";
                //sender.Session.Response.userLogin.Userinfo = new NUserInfo();
                //sender.Session.Response.userLogin.Userinfo.Id = (int)user.ID;
                //sender.Session.Response.userLogin.Userinfo.Player = new NPlayerInfo();
                //sender.Session.Response.userLogin.Userinfo.Player.Id = user.Player.ID;
                //foreach (var c in user.Player.Characters)
                //{
                //    NCharacterInfo info = new NCharacterInfo();
                //    info.Id = c.ID;
                //    info.Name = c.Name;
                //    info.Type = CharacterType.Player;
                //    info.Class = (CharacterClass)c.Class;
                //    info.ConfigId = c.ID;
                //    sender.Session.Response.userLogin.Userinfo.Player.Characters.Add(info);
                //}

            }
            sender.SendResponse();
        }

        
    }
}
