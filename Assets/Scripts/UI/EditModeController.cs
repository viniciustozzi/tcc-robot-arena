using UnityEngine;
using System.Collections.Generic;
using System;

public class EditModeController : MonoBehaviour
{
    private ToUseBlocks m_toUseBlocks;
    private UsedBlocks m_usedBlocks;
    private TabsController m_tabsController;

    public Transform ToUseTransform { get { return m_toUseBlocks.transform; } }
    public Transform UsedBlocksTransform { get { return m_usedBlocks.transform; } }

    void Awake()
    {
        VariableController.ClearAllVariables();
        VariableController.DeclareVariable("VarA", VariableType.Number, 1);
        VariableController.DeclareVariable("VarB", VariableType.Bool, true);
        VariableController.DeclareVariable("VarC", VariableType.String, "var string");

        m_toUseBlocks = FindObjectOfType<ToUseBlocks>();
        m_usedBlocks = FindObjectOfType<UsedBlocks>();
        m_tabsController = FindObjectOfType<TabsController>();
    }

    public void SaveRobot()
    {
        //É necessário pegar a raiz (onde começa) o algoritmo do robo
        var root = FindObjectOfType<OnBegin>();
        var x = root.GetLogicBlockStructure();

        Debug.Log(x);
    }

    public void ResetBlocksToUse(BlockCategory category)
    {
        m_toUseBlocks.ResetBlockList(category);
    }
}
