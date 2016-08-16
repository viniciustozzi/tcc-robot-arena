using UnityEngine;
using System;

public class TabsController : MonoBehaviour
{
    private CurrentBlocksAvaible m_currentBlocks;

    public void SetBlockGroup(int group)
    {
        if (group < 0 || group > Enum.GetNames(typeof(CurrentBlocksAvaible)).Length)
        {
            Debug.LogWarning("Número de grupo de blocos inválido!");
            return;
        }
            
        m_currentBlocks = (CurrentBlocksAvaible)group;

        Debug.Log("mcurretBLock: " + m_currentBlocks);
    }

    public void UpdateBlockGroup()
    {

    }
}
