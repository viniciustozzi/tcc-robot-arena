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

        BlockCategory category = (BlockCategory)group;

        m_editMode.ResetBlocksToUse(category);
    }
}
