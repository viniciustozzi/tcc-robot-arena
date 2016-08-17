using UnityEngine;
using System;
using System.Collections.Generic;

public class TabsController : MonoBehaviour
{
    private CurrentBlocksAvaible m_currentBlocks;

    public Transform scrollContent;

    public List<GameObject> RobotActionsBlocks;
    public List<GameObject> VariablesBlocks;
    public List<GameObject> EventsBlocks;
    public List<GameObject> OperatorsBlocks;
    public List<GameObject> ControlsBlocks;

    public void SetBlockGroup(int group)
    {
        if (group < 0 || group > Enum.GetNames(typeof(CurrentBlocksAvaible)).Length)
        {
            Debug.LogWarning("Número de grupo de blocos inválido!");
            return;
        }
            
        m_currentBlocks = (CurrentBlocksAvaible)group;
    }

    public void UpdateBlockGroup()
    {
        switch (m_currentBlocks)
        {
            case CurrentBlocksAvaible.RobotActions:

                foreach (var item in RobotActionsBlocks)
                {

                }

                break;
            case CurrentBlocksAvaible.Variables:
                break;
            case CurrentBlocksAvaible.Events:
                break;
            case CurrentBlocksAvaible.Operators:
                break;
            case CurrentBlocksAvaible.Controls:
                break;
        }
    }
}
