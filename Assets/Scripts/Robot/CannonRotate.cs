using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CannonRotate : AbstractBlock
{
    public float Degrees { get; set; }

    public override List<AbstractBlock> LogicBlocks { get; set; }
    
    private Transform m_transformToChange;
    private float m_rotationSpeed;
    private Action<bool> m_callback;
    private float m_time;

    public override void Initialize()
    {
        m_rotationSpeed = 30;
        m_transformToChange = transform.FindChild("RobotModel").FindChild("RobotChassis").FindChild("CannonPivot");
    }

    public override void Run(Action<bool> blockCallback)
    {
        m_callback = blockCallback;

        turnCommand();
    }

    IEnumerator RotateObject(Transform objToRotate, float yRotation, float speed)
    {
        float inc = (yRotation / speed) * Time.deltaTime;
        float finalRotation = objToRotate.eulerAngles.y + yRotation;

        do
        {
            m_time += Time.deltaTime;

            objToRotate.rotation = Quaternion.Slerp(objToRotate.rotation, Quaternion.Euler(objToRotate.eulerAngles.x, finalRotation, objToRotate.eulerAngles.z), inc);  //Quaternion.Euler(0, objToRotate.eulerAngles.y + inc , 0);
            
            if (m_time >= 2)
            {
                m_time = 0;

                IsRunning = false;

                if (m_callback != null)
                    m_callback.Invoke(false);

                break;
            }

            yield return null;

        } while (true);
    }

    /// <summary>
    /// Rotate the robot an amount of degrees
    /// </summary>
	private void turnCommand()
    {
        StartCoroutine(RotateObject(m_transformToChange, Degrees, m_rotationSpeed));
    }

    private Vector3 DegreeToVector(float degrees)
    {
        float radians = degrees * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
    }

    public override void Stop()
    {
        if (!IsRunning) return;

        m_callback.Invoke(true);

        base.Stop();
    }
}
