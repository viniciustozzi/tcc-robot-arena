using UnityEngine;
using System.Collections;

public class UI_Shoot : UIBlock
{
    protected override AbstractBlock SetupBlockInfo()
    {
        //GameObject go = new GameObject();
        Controller.Instance.CURRENT_ROBOT.name = "Shoot";
        var shoot = Controller.Instance.CURRENT_ROBOT.AddComponent<Shoot>();

        return shoot;
    }
}
