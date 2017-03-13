using UnityEngine;
using System.Collections;
using System;

public class RobotRotate : MonoBehaviour {

    private Rigidbody m_rigidbody;

    private bool m_turn;
    private float m_degrees;
    private Action m_onFinishTurn;


    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //For testing!!!
        if (Input.GetKeyDown(KeyCode.R))
            TurnCommand(30);

        if (m_turn)
        {
            turn();
        }
    }

    /// <summary>
    /// Rotate the robot an amount of degrees
    /// </summary>
    public void TurnCommand(float degrees, Action callback = null)
    {
        m_turn = true;
        m_onFinishTurn = callback;
    }

    private void turn()
    {
        m_rigidbody.MoveRotation(m_rigidbody.rotation * Quaternion.Euler(DegreeToVector(m_degrees)));
    }

    private Vector3 DegreeToVector(float degrees)
    {
        float radians = degrees * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
    }
}
