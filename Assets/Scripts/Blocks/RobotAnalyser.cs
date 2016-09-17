using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RobotAnalyser : MonoBehaviour
{
    
    public void TestRobot(ExecuteCycle testCycle)
    {
        Controller.Instance.CURRENT_ROBOT.name = "ROBO";
        var rigidbody = Controller.Instance.CURRENT_ROBOT.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        ExecuteCycle myCycle = (ExecuteCycle)Controller.Instance.CURRENT_ROBOT.AddComponent(typeof(ExecuteCycle));

        myCycle = testCycle;

        myCycle.Initialize();

        myCycle.Run(null);
    }
}
