using UnityEngine;
using System;
using System.Collections.Generic;

public class TabsController : MonoBehaviour
{
    private EditModeController m_editMode;

    void Awake()
    {
        m_editMode = FindObjectOfType<EditModeController>();
    }

    public void SetBlockGroup(int group)
    {
        if (group < 0 || group > Enum.GetNames(typeof(BlockCategory)).Length)
        {
            Debug.LogWarning("Número de grupo de blocos inválido!");
            return;
        }

        //É o grupo de variáveis?
        if (group == 1)
        {
            //Deve colocar no scroll as variáveis que já foram declaradas
            
        }

        BlockCategory category = (BlockCategory)group;

        m_editMode.ResetBlocksToUse(category);
    }
}