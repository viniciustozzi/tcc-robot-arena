using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CannonRotate : AbstractBlock
{
    public float Degrees { get; set; }

    public override List<AbstractBlock> LogicBlocks { get; set; }

    private Action m_onFinishTurn;
    private Transform m_transformToChange;
    private float m_rotationSpeed;

    public override void Initialize()
    {
        m_rotationSpeed = 30;
        m_transformToChange = transform.FindChild("RobotModel").FindChild("RobotChassis").FindChild("CannonPivot");
    }

    public override void Run(Action<bool> blockCallback)
    {
        turnCommand(blockCallback);
    }

    IEnumerator RotateObject(Transform objToRotate, float yRotation, float speed, Action<bool> onRotateCompleted)
    {
        float inc = (yRotation / speed) * Time.deltaTime;
        float finalRotation = objToRotate.eulerAngles.y + yRotation;

        do
        {
            objToRotate.rotation = Quaternion.Slerp(objToRotate.rotation, Quaternion.Euler(objToRotate.eulerAngles.x, finalRotation, objToRotate.eulerAngles.z), inc);  //Quaternion.Euler(0, objToRotate.eulerAngles.y + inc , 0);

            yield return null;

            if (Math.Round(objToRotate.eulerAngles.y, 1) == Math.Round(finalRotation, 1))
            {
                if (onRotateCompleted != null)
                    onRotateCompleted.Invoke(false);

                break;
            }

        } while (true);
    }

    /// <summary>
    /// Rotate the robot an amount of degrees
    /// </summary>
	private void turnCommand(Action<bool> callback = null)
    {
        StartCoroutine(RotateObject(m_transformToChange, Degrees, m_rotationSpeed, callback));
    }

    private Vector3 DegreeToVector(float degrees)
    {
        float radians = degrees * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
    }

    public override void Stop()
    {
        throw new NotImplementedException();
    }
}
