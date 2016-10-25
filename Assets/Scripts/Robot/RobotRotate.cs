using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class RobotRotate : AbstractBlock
{
    private Transform m_transformToChange;

    public float Degrees { get; set; }

    public override List<AbstractBlock> LogicBlocks { get; set; }

    private Action m_onFinishTurn;
    private float m_rotationSpeed;
    private Action<bool> m_callback;
    private bool m_canRotate;


    public override void Initialize()
    {
        m_rotationSpeed = 15f;
        m_transformToChange = transform;
    }

    public override void Run(Action<bool> blockCallback)
    {
        m_callback = blockCallback;

        turnCommand();

        m_canRotate = true;
    }

    IEnumerator RotateObject(Transform objToRotate, float yRotation, float speed, Action<bool> onRotateCompleted)
    {
        float inc = (yRotation / speed) * Time.deltaTime;
        float finalRotation = objToRotate.eulerAngles.y + yRotation;

        do
        {
            if (!m_canRotate)
                break;

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
	private void turnCommand()
    {
        StartCoroutine(RotateObject(m_transformToChange, Degrees, m_rotationSpeed, m_callback));
    }

    private Vector3 DegreeToVector(float degrees)
    {
        float radians = degrees * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
    }

    public override void Stop()
    {
        if (!IsRunning) return;

        m_canRotate = false;
        m_callback.Invoke(true);

        base.Stop();
    }
}
