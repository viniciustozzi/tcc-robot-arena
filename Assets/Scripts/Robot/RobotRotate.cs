﻿using UnityEngine;
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

    public override void Initialize()
    {
        m_rotationSpeed = 45f;
        m_transformToChange = transform;
    }

    public override void Run(Action blockCallback)
    {
        turnCommand(blockCallback);
    }

    IEnumerator RotateObject(Transform objToRotate, float yRotation, float speed, Action onRotateCompleted)
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
                    onRotateCompleted.Invoke();

                break;
            }

        } while (true);
    }

    /// <summary>
    /// Rotate the robot an amount of degrees
    /// </summary>
	private void turnCommand(Action callback = null)
    {
        StartCoroutine(RotateObject(m_transformToChange, Degrees, m_rotationSpeed, callback));
    }

    private Vector3 DegreeToVector(float degrees)
    {
        float radians = degrees * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
    }
}
