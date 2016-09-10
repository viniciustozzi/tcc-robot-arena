using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnBegin : UIBlock
{
    protected override AbstractBlock SetupBlockInfo()
    {
        GameObject go = new GameObject();
        go.name = "ExecuteCycle";
        ExecuteCycle cycle = go.AddComponent<ExecuteCycle>();

        return cycle;
    }
}
