using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class UI_IfBlock : UIBlock
{
    public List<UI_RelationalOperation> BooleanExpressions;

    protected override void Awake()
    {
        base.Awake();
    }

    public override bool CanHaveBlocks
    {
        get { return true; }
    }

}
