using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class UI_MoveAhead : UIBlock
{
    public InputField input_distance;

    private MoveAhead m_moveAhead;

    public MoveAhead GetMoveAheadBlock()
    {
        m_moveAhead.Distance = Distance;
        return m_moveAhead;
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
