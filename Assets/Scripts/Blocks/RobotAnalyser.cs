using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RobotAnalyser : MonoBehaviour
{
    private ExecuteCycle m_mainCycle;
    private OnWallCollisionCycle m_wallCycle;
    private OnFindRobotCycle m_onFindCycle;

    public void TestRobot(ExecuteCycle mainCycle, OnWallCollisionCycle wallCycle, OnFindRobotCycle onFindCycle)
    {
        m_mainCycle = mainCycle;
        m_wallCycle = wallCycle;
        m_onFindCycle = onFindCycle;

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

        if (m_onFindCycle != null)
            m_onFindCycle.Initialize();
    }

    public void RunMainCycle()
    {
        if (m_mainCycle != null)
            m_mainCycle.Run(null);
    }
}
