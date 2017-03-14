using UnityEngine;
using System.Collections;

public class RobotMain
{
    public string Name { get; set; }
    public ExecuteCycle MainCycle { get; set; }
    public OnWallCollisionCycle OnWallCycle { get; set; }
    public OnFindRobotCycle OnFindCycle { get; set; }
}
