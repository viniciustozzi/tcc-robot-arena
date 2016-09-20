using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class UI_MoveAhead : UIBlock
{
    public InputField input_distance;

    protected override AbstractBlock SetupBlockInfo()
    {
        var move = Controller.Instance.CURRENT_ROBOT.AddComponent<MoveAhead>();
        move.Distance = Distance;

        return move;
    }

    public int Distance
    {
        get
        {
            int distance = 0;

            if (!int.TryParse(input_distance.text, out distance))
                Debug.LogWarning("Erro ao converter distância do bloco MoveAhead para inteiro");

            return distance;
        }
    }
}
