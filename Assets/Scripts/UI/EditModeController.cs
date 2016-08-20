using UnityEngine;
using System.Collections.Generic;
using System;

public class EditModeController : MonoBehaviour
{
    public List<UIBlock> UIBlocks;

    private ToUseBlocks m_toUseBlocks;
    private UsedBlocks m_usedBlocks;
    private TabsController m_tabsController;

    public Transform ToUseTransform { get { return m_toUseBlocks.transform; } }
    public Transform UsedBlocksTransform { get { return m_usedBlocks.transform; } }

    public bool DroppedOnBLock { get; set; }

    void Awake()
    {
        m_toUseBlocks = FindObjectOfType<ToUseBlocks>();
        m_usedBlocks = FindObjectOfType<UsedBlocks>();
        m_tabsController = FindObjectOfType<TabsController>();

        #region TESTE
        //Criação de variaveis para testes:
        VariableController.DeclareVariable("x", VariableType.Number, 3);
        VariableController.DeclareVariable("y", VariableType.Number, 1);
        #endregion
    }

    public void UpdateBlocksToUse()
    {
        m_tabsController.UpdateBlockGroup();
    }
}
