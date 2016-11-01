using UnityEngine;
using System.Collections;

public class ModalBuilder
{
    public GameObject Modal
    {
        get
        {
            var modalPrefab = Resources.Load<GameObject>("Prefabs/pnl_Modal");
            //TODO: Terminar de configurar a modal antes de enviar
            //modalPrefab.GetComponent<ModalBehaviour>().SetInfo(message, )
            return modalPrefab;
        }
    }

    private string m_message;

    public void SetMessage(string message)
    {
        m_message = message;
    }

    public void SetOkButton()
    {
        
    }
}