using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UI_IfBlock : UIBlock
{
    public UI_BoolOperation booleanExpression;
    
    protected override AbstractBlock SetupBlockInfo()
    {
        Controller.Instance.CURRENT_ROBOT.name = "While";
        var whileComp = Controller.Instance.CURRENT_ROBOT.AddComponent<While>();
        whileComp.expression = booleanExpression.GetBoolOperation();
        return whileComp;
    }
}