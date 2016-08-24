using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class ToUseBlocks : MonoBehaviour
{
    public Transform scrollContent;

    public List<GameObject> RobotActionsBlocks;
    public List<GameObject> VariablesBlocks;
    public List<GameObject> EventsBlocks;
    public List<GameObject> OperatorsBlocks;
    public List<GameObject> ControlsBlocks;

    public void ResetBlockList(BlockCategory currentCategory)
    {
        clearScrollContent();

        switch (currentCategory)
        {
            case BlockCategory.RobotActions:
                addToScroll(RobotActionsBlocks); break;
            case BlockCategory.Variables:
                addToScroll(VariablesBlocks); break;
            case BlockCategory.Events:
                addToScroll(EventsBlocks); break;
            case BlockCategory.Operators:
                addToScroll(OperatorsBlocks); break;
            case BlockCategory.Controls:
                addToScroll(ControlsBlocks); break;
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
