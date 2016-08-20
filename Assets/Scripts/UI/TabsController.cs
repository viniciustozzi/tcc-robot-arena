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

        UpdateBlockGroup();
    }

    public void UpdateBlockGroup()
    {
        clearScrollContent();

        switch (m_currentBlocks)
        {
            case CurrentBlocksAvaible.RobotActions:

                addToScroll(RobotActionsBlocks);

                break;
            case CurrentBlocksAvaible.Variables:

                addToScroll(VariablesBlocks);

                break;
            case CurrentBlocksAvaible.Events:

                addToScroll(EventsBlocks);

                break;
            case CurrentBlocksAvaible.Operators:

                addToScroll(OperatorsBlocks);

                break;
            case CurrentBlocksAvaible.Controls:
                addToScroll(ControlsBlocks);
                break;
        }
    }
    
    private void addToScroll(List<GameObject> blockListType)
    {
        foreach (var item in blockListType)
        {
            var blockObj = Instantiate(item) as GameObject;
            blockObj.transform.SetParent(scrollContent);
            blockObj.transform.ResetScale();
        }
    }

    private void clearScrollContent()
    {
        //Destroy all blocks current in the scroll list
        foreach (Transform item in scrollContent)
        {
            Destroy(item.gameObject);
        }
    }
}
