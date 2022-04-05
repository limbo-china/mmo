using UnityEngine;

namespace UI
{
    public class MessageBox : Singleton<MessageBox>
    {
        GameObject prefabs = null;

        public UIMessageBox Show(string message, string title = "", MessageBoxType type = MessageBoxType.Information, string btnOK = "", string btnCancel = "")
        {
            if (prefabs == null)
            {
                prefabs = Resources.Load<GameObject>("UI/UIMessageBox");
            }

            GameObject go = (GameObject)GameObject.Instantiate(prefabs);
            UIMessageBox msgbox = go.GetComponent<UIMessageBox>();
            msgbox.Init(title, message, type, btnOK, btnCancel);
            return msgbox;
        }

    }
}
