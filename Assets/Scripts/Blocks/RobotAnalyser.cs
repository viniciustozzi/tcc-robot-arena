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
        
        if (testCycle != null)
            testCycle.Initialize();

        if (wallCycle != null)
            wallCycle.Initialize();

        //Inicia a execução de todos os blocos da rotina principal (OnBegin)
        if (testCycle != null)
            testCycle.Run(null);
    }
}
