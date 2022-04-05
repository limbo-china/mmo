using Message;
using Service;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UILogin :MonoSingleton<UILogin>
    {
        public InputField username;
        public InputField password;
        public Button buttonLogin;
        public Button buttonRegister;

        void Start()
        {
            UIRegister.Instance.gameObject.SetActive(false);
            LoginService.Instance.OnLogin = OnLogin;
        }
        public void OnClickButtonLogin()
        {
            if (string.IsNullOrEmpty(this.username.text))
            {
                MessageBox.Instance.Show("请输入账号");
                return;
            }
            if (string.IsNullOrEmpty(this.password.text))
            {
                MessageBox.Instance.Show("请输入密码");
                return;
            };

            LoginService.Instance.Login(this.username.text, this.password.text);

        }

        public void OnClickButtonRegister()
        {
            UIRegister.Instance.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }

        void OnLogin(Result result, string message)
        {
            if (result == Result.Success)
            {
                MessageBox.Instance.Show("登录成功");
                //Game.SceneManager.Instance.UnloadScene("SceneLogin");
                Game.SceneManager.Instance.LoadScene("SceneCharacter");
            }
            else
                MessageBox.Instance.Show(message, "错误", MessageBoxType.Error);
        }
    }

    
}
