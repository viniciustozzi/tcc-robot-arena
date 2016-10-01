using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_WhileBlock : UIBlock
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
