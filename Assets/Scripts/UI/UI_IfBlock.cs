using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class UI_IfBlock : UIBlock
{
    public List<UI_RelationalOperation> BooleanExpressions;

    private List<UIBlock> m_blocks;

    protected override void Awake()
    {
        m_blocks = new List<UIBlock>();

        base.Awake();
    }

    public override bool CanHaveBlocks
    {
        get
        {
            return true;
        }
    }

    public override List<UIBlock> UI_Blocks
    {
        get
        {
            return m_blocks;
        }
    }
}
