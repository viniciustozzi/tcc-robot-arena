using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnBegin : UIBlock
{
    protected override IBlock SetupBlockInfo()
    {
        ExecuteCycle cycle = new ExecuteCycle();
        
        return cycle;
    }
}
