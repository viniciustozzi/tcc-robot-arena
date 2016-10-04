using UnityEngine;
using System.Collections;

public class OnWallCollision : UIBlock
{
    protected override AbstractBlock SetupBlockInfo()
    {
        GameObject go = new GameObject();
        go.name = "ExecuteCycle";
        ExecuteCycle cycle = go.GetComponent<ExecuteCycle>();

        if (cycle == null)
        {
            cycle = go.AddComponent<ExecuteCycle>();
        }

        Destroy(go);
        
        return cycle;
    }
}
