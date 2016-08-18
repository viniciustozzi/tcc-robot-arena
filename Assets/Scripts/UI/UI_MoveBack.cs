using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_MoveBack : MonoBehaviour
{
    public InputField input_distance;

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
