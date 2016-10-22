using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UI_OnBegin : UIBlock
{
    protected override AbstractBlock SetupBlockInfo()
    {
        GameObject go = new GameObject();
        go.name = "ExecuteCycle";
        ExecuteCycle cycle = go.AddComponent<ExecuteCycle>();

        Destroy(go);
        
        return cycle;
    }
}
