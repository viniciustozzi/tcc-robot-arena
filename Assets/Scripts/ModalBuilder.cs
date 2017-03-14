using UnityEngine;
using System.Collections;
using System;

public class ModalBuilder
{
    public GameObject Modal
    {
        get
        {
            var modalPrefab = Resources.Load<GameObject>("Prefabs/pnl_Modal");
            modalPrefab.GetComponent<ModalBehaviour>().SetInfo(message, )
            return modalPrefab;
        }
    }

    private string m_message;

    public void SetMessage(string message)
    {
        m_message = message;
    }

    public void SetOneButton(Action onOkClick)
    {
        
    }

    public void SetTwoButtons()
    {
        
    }

    public void SetCloseCallback(Action onCloseCallback)
    {

    }
}