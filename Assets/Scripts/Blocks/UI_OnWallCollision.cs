using UnityEngine;
using System.Collections;

public class UI_OnWallCollision : UIBlock
{
    protected override AbstractBlock SetupBlockInfo()
    {
        GameObject go = new GameObject();
        go.name = "OnWallCollisionCycle";
        OnWallCollisionCycle cycle = go.GetComponent<OnWallCollisionCycle>();

        if (cycle == null)
        {
            cycle = go.AddComponent<OnWallCollisionCycle>();
        }
        
        return cycle;
    }
}
