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
        Controller.Instance.CURRENT_ROBOT.name = "If";
        var ifComp = Controller.Instance.CURRENT_ROBOT.AddComponent<If>();
        ifComp.condition = booleanExpression.GetBoolOperation();
        return ifComp;
    }
}