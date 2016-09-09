using UnityEngine;
using System.Collections;

public class UI_Shoot : UIBlock
{
    protected override AbstractBlock SetupBlockInfo()
    {
        GameObject go = new GameObject();
        go.name = "Shoot";
        var shoot = go.AddComponent<Shoot>();

        return shoot;
    }
}
