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

    void Awake()
    {
        m_toUseBlocks = FindObjectOfType<ToUseBlocks>();
        m_usedBlocks = FindObjectOfType<UsedBlocks>();
        m_tabsController = FindObjectOfType<TabsController>();
    }

    public void ResetBlocksToUse(BlockCategory category)
    {
        m_toUseBlocks.ResetBlockList(category);
    }
    
}
