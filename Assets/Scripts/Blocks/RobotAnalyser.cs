using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RobotAnalyser : MonoBehaviour
{
    private RobotMain m_robot;

    public void TestRobot(RobotMain robot)
    {
        m_robot = robot;

        Controller.Instance.CURRENT_EDIT_ROBOT.name = "ROBO";

        InitializeCycles();

        //Inicia a execução de todos os blocos da rotina principal (OnBegin)
        RunMainCycle();
    }

    public void InitializeCycles()
    {
        if (m_robot.MainCycle != null)
            m_robot.MainCycle.Initialize();

        if (m_robot.OnWallCycle != null)
            m_robot.OnWallCycle.Initialize();

        if (m_robot.OnFindCycle != null)
            m_robot.OnFindCycle.Initialize();
    }

    public void RunMainCycle()
    {
        if (m_robot.MainCycle != null)
            m_robot.MainCycle.Run(null);
    }
}
