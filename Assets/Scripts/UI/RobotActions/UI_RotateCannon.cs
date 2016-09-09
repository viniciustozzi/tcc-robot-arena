using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_RotateCannon : UIBlock
{
    public InputField input_angle;

    protected override AbstractBlock SetupBlockInfo()
    {
        GameObject go = new GameObject();
        go.name = "RotateCannon";
        var rotateCannon = go.AddComponent<CannonRotate>();
        rotateCannon.Degrees = Angle;

        return rotateCannon;
    }

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
