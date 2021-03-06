using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public enum MessageBoxType
    {
        Information = 1,
        Confirm = 2,
        Error = 3
    }

    public class UIMessageBox : MonoSingleton<UIMessageBox>
    {
        public Text title;
        public Text message;
        public Image[] icons;
        public Button buttonYes;
        public Button buttonNo;

        public Text buttonYesText;
        public Text buttonNoText;
        public UnityAction OnYes;

       
        public void Init(string title, string message, MessageBoxType type = MessageBoxType.Information, string btnOK = "", string btnCancel = "")
        {
            if (!string.IsNullOrEmpty(title)) this.title.text = title;
            this.message.text = message;
            this.icons[0].enabled = type == MessageBoxType.Information;
            this.icons[1].enabled = type == MessageBoxType.Confirm;
            this.icons[2].enabled = type == MessageBoxType.Error;

            if (!string.IsNullOrEmpty(btnOK)) this.buttonYesText.text = btnOK;
            if (!string.IsNullOrEmpty(btnCancel)) this.buttonNoText.text = btnCancel;

            this.buttonYes.onClick.AddListener(OnClickYes);
            this.buttonNo.onClick.AddListener(OnClickNo);

            this.buttonNo.gameObject.SetActive(type == MessageBoxType.Confirm);

        }

        void OnClickYes()
        {
            Destroy(this.gameObject);
            if (this.OnYes != null)
                this.OnYes();
        }

        void OnClickNo()
        {
            Destroy(this.gameObject);
            //if (this.OnNo != null)
            //    this.OnNo();
        }
    }
}