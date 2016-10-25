using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RobotAnalyser : MonoBehaviour
{
    private ExecuteCycle m_mainCycle;
    private OnWallCollisionCycle m_wallCycle;

    public void TestRobot(ExecuteCycle mainCycle, OnWallCollisionCycle wallCycle)
    {
        m_mainCycle = mainCycle;
        m_wallCycle = wallCycle;

        Controller.Instance.CURRENT_ROBOT.name = "ROBO";

        InitializeCycles();

        //Inicia a execução de todos os blocos da rotina principal (OnBegin)
        RunMainCycle();
    }

    public void InitializeCycles()
    {
        if (m_mainCycle != null)
            m_mainCycle.Initialize();

        if (m_wallCycle != null)
            m_wallCycle.Initialize();
    }

    public void RunMainCycle()
    {
        if (m_mainCycle != null)
            m_mainCycle.Run(null);
    }
}
