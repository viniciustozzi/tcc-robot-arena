using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_RotateCannon : MonoBehaviour
{
    public InputField input_angle;

    public int Angle
    {
        get
        {
            int angle = 0;

            if (!int.TryParse(input_angle.text, out angle))
                Debug.LogWarning("Erro ao converter angulo do bloco RotateRobot para inteiro");

            return angle;
        }
    }
}
