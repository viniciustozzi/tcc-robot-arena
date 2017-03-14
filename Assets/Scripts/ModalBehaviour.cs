using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ModalBehaviour : MonoBehaviour
{
    public Text textMsg;
    public GameObject pnl_OneButton;
    public GameObject pnl_TwoButtons;

    private Action m_onCloseCallback;

    public void SetInfo(string message, Action onCloseCallback = null, Action onButtonOkCallback = null)
    {
        textMsg.text = message;

        m_onCloseCallback = onCloseCallback;
    }

    public void SetInfo(string message, Action onClosecallback = null, )

    public void OnOkClick()
    {
        if (m_onCloseCallback != null)
            m_onCloseCallback.Invoke();

        Controller.Instance.EnableModal();
    }
}
