using UnityEngine;
using System.Collections;

public class UI_OnFindRobot : UIBlock
{
    protected override AbstractBlock SetupBlockInfo()
    {
        OnFindRobotCycle onRobotFind = Controller.Instance.CURRENT_ROBOT.AddComponent<OnFindRobotCycle>();

        return onRobotFind;
    }
}
