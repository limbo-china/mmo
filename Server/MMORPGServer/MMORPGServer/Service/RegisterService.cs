using Message;
using MMORPGServer.Entity;
using Net;
using System.Linq;

namespace Service
{
    public class RegisterService : Singleton<RegisterService>
    {
        public RegisterService()
        {
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<UserRegisterRequest>(this.OnRegister);
        }
        public void Init()
        {

        }

        void OnRegister(NetConnection<NetSession> conn, UserRegisterRequest request)
        {
            Log.InfoFormat("UserRegisterRequest: User:{0}  Pass:{1}", request.User, request.Passward);
            conn.Session.Response.userRegister = new UserRegisterResponse();

           tuser user = DBService.Instance.Entities.tuser.Where(u => u.UserName == request.User).FirstOrDefault();
            if (user != null)
            {
                conn.Session.Response.userRegister.Result = Result.Failed;
                conn.Session.Response.userRegister.Errormsg = "用户已存在.";
            }
            else
            {
                //TPlayer player = DBService.Instance.Entities.Players.Add(new TPlayer());
                DBService.Instance.Entities.tuser.Add(new tuser { UserName = request.User, Password = request.Passward});
                DBService.Instance.Entities.SaveChanges();
                conn.Session.Response.userRegister.Result = Result.Success;
                conn.Session.Response.userRegister.Errormsg = "None";
            }
            conn.SendResponse();
        }
    }
}
