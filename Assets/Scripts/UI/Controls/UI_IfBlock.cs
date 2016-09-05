using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UI_IfBlock : UIBlock
{
    public List<UI_BoolOperation> BooleanExpressions;

    protected override void Awake()
    {
        CanHaveBlocks = true;

        base.Awake();
    }
}
