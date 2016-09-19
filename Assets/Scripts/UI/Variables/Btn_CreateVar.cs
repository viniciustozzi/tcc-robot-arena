using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Btn_CreateVar : MonoBehaviour
{
    private EditModeController m_editMode;
    private Button m_button;

    void Start()
    {
        m_editMode = FindObjectOfType<EditModeController>();
        m_button = GetComponent<Button>();
    }


}
