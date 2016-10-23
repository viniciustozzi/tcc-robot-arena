using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RobotAnalyser : MonoBehaviour
{
    public void TestRobot(ExecuteCycle testCycle, OnWallCollisionCycle wallCycle)
    {
        Controller.Instance.CURRENT_ROBOT.name = "ROBO";
        var rigidbody = Controller.Instance.CURRENT_ROBOT.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        ExecuteCycle myCycle = (ExecuteCycle)Controller.Instance.CURRENT_ROBOT.AddComponent(typeof(ExecuteCycle));
        OnWallCollisionCycle myWallCycle = (OnWallCollisionCycle)Controller.Instance.CURRENT_ROBOT.AddComponent(typeof(OnWallCollisionCycle));

        myCycle = testCycle;
        myWallCycle = wallCycle;

        if (myCycle != null)
            myCycle.Initialize();

        if (myWallCycle != null)
            myWallCycle.Initialize();

        //Inicia a execução de todos os blocos da rotina principal (OnBegin)
        if (myCycle != null)
            myCycle.Run(null);
    }
}
