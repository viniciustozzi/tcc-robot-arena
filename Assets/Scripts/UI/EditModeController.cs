using UnityEngine;
using System.Collections.Generic;

public class EditModeController : MonoBehaviour
{
    public List<UIBlock> UIBlocks;

    private ToUseBlocks m_toUseBlocks;
    private UsedBlocks m_usedBlocks;

    public Transform ToUseTransform { get { return m_toUseBlocks.transform; } }
    public Transform UsedBlocksTransform { get { return m_usedBlocks.transform; } }

    void Awake()
    {
        m_toUseBlocks = FindObjectOfType<ToUseBlocks>();
        m_usedBlocks = FindObjectOfType<UsedBlocks>();

        #region TESTE
        //Criação de variaveis para testes:
        VariableController.DeclareVariable("x", VariableType.Number, 3);
        VariableController.DeclareVariable("y", VariableType.Number, 1);
        #endregion
    }

    public void SetBlockOnToUse(UIBlock block)
    {
        block.transform.SetParent(m_toUseBlocks.transform);
    }

}
