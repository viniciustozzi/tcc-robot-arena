using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_MoveBack : UIBlock
{
    public InputField input_distance;

    protected override AbstractBlock SetupBlockInfo()
    {
        GameObject go = new GameObject();
        go.name = "MoveBack";
        var move = go.AddComponent<MoveBack>();
        move.Distance = Distance;

        return move;
    }

    public int Distance
    {
        get
        {
            int distance = 0;

            if (!int.TryParse(input_distance.text, out distance))
                Debug.LogWarning("Erro ao converter distância do bloco MoveBack para inteiro");

            return distance;
        }
    }
}
