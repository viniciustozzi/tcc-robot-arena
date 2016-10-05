using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_OnBegin : UIBlock
{
    protected override AbstractBlock SetupBlockInfo()
    {
        GameObject go = new GameObject();
        go.name = "ExecuteCycle";
        ExecuteCycle cycle = go.AddComponent<ExecuteCycle>();

        Destroy(go);

        //Como pegar os blocos daqui?

        return cycle;
    }
}
