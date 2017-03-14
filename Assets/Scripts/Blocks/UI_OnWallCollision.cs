using UnityEngine;
using System.Collections;

public class UI_OnWallCollision : UIBlock
{
    protected override AbstractBlock SetupBlockInfo()
    {
        OnWallCollisionCycle onWallCollisionCycle = Controller.Instance.CURRENT_EDIT_ROBOT.AddComponent<OnWallCollisionCycle>();
        
        return onWallCollisionCycle;
    }
}
