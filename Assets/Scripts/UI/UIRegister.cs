using Message;
using Service;
using UnityEngine.UI;

namespace UI
{
    public class UIRegister : MonoSingleton<UIRegister>
    {
        public InputField username;
        public InputField password;
        public InputField passwordConfirm;
        public Button buttonRegister;

        void Start()
        {
            RegisterService.Instance.OnRegister = OnRegister;
        }
        public void OnClickButtonRegister()
        {
            if (string.IsNullOrEmpty(this.username.text))
            {
                MessageBox.Instance.Show("�������˺�");
                return;
            }
            if (string.IsNullOrEmpty(this.password.text))
            {
                MessageBox.Instance.Show("����������");
                return;
            }
            if (string.IsNullOrEmpty(this.passwordConfirm.text))
            {
                MessageBox.Instance.Show("������ȷ������");
                return;
            }
            if (this.password.text != this.passwordConfirm.text)
            {
                MessageBox.Instance.Show("������������벻һ��");
                return;
            }
            RegisterService.Instance.Register(this.username.text, this.password.text);
        }

        void OnRegister(Result result, string message)
        {
            if (result == Result.Success)
            {
                MessageBox.Instance.Show("ע��ɹ�,���¼").OnYes = this.CloseRegisterWindow;
            }
            else
                MessageBox.Instance.Show(message, "����", MessageBoxType.Error);
        }
        void CloseRegisterWindow()
        {
            this.gameObject.SetActive(false);
            UILogin.Instance.gameObject.SetActive(true);
        }
    }
}
