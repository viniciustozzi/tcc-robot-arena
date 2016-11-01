using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class UI_OnBegin : UIBlock
{
    protected override AbstractBlock SetupBlockInfo()
    {
        ExecuteCycle cycle = Controller.Instance.CURRENT_EDIT_ROBOT.AddComponent<ExecuteCycle>();
   
        return cycle;
    }
}
