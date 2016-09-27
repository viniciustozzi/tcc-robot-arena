using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_WhileBlock : UIBlock
{
    public List<UI_RelationalOperation> BooleanExpressions;

    protected override AbstractBlock SetupBlockInfo()
    {
        return base.SetupBlockInfo();
    }
}
