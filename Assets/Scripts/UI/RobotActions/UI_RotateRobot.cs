using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_RotateRobot : UIBlock
{
    public InputField input_angle;

    protected override AbstractBlock SetupBlockInfo()
    {
        //GameObject go = new GameObject();
        Controller.Instance.CURRENT_EDIT_ROBOT.name = "RotateRobot";
        var rotateRobot = Controller.Instance.CURRENT_EDIT_ROBOT.AddComponent<RobotRotate>();
        rotateRobot.Degrees = Angle;

        return rotateRobot;
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
