using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UI_IfBlock : UIBlock
{
    public List<UI_RelationalOperation> BooleanExpressions;
    public HorizontalLayoutGroup horizontalLayout;

    protected override void Awake()
    {
        CanHaveBlocks = true;

        base.Awake();
    }
}
