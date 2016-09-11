using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RobotAnalyser : MonoBehaviour
{
    public List<UIBlock> UIBlocksList { get; set; }

    public void TestRobot(ExecuteCycle testCycle)
    {
        GameObject robot = new GameObject();

        robot.name = "ROBO";
        var rigidbody = robot.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        ExecuteCycle myCycle = (ExecuteCycle)robot.AddComponent(typeof(ExecuteCycle));
        myCycle = testCycle;

        myCycle.Initialize();

        myCycle.Run(null);
    }
}
