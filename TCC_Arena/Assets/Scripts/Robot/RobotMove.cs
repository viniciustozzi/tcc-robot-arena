using UnityEngine;
using System.Collections;
using System;

public class RobotMove : MonoBehaviour
{
    public float speed = 3;

    private Rigidbody m_rigidbody;
    private bool m_ahead;
    private bool m_back;
    private float m_time;
    private float m_distance;

    private Action m_onFinishMove;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Testing!!!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AheadCommand(5,()=> 
            {
                Debug.Log("AHEAD COMMAND TERMINOU!!!");
            });
        }
        else if (Input.GetKeyDown(KeyCode.A))
            BackCommand(7);

        if (m_ahead || m_back)
        {
            movement();
        }
    }

    private void movement()
    {
        m_time += Time.deltaTime;

        if (m_time <= m_distance / speed)
        {
            if (m_ahead)
                m_rigidbody.velocity = transform.forward * speed * Time.deltaTime;
            else if (m_back)
                m_rigidbody.velocity = transform.forward * -speed * Time.deltaTime;
        }

        else
        {
            if (m_onFinishMove != null)
                m_onFinishMove.Invoke();

            resetVelocity();
        }
    }

    /// <summary>
    /// Move the robot in the z-axis with positive speed
    /// </summary>
    public void AheadCommand(float distance, Action callback = null)
    {
        resetVelocity();

        m_ahead = true;
        m_distance = distance;
        m_onFinishMove = callback;
    }
    /// <summary>
    /// Move the robot in the z-axis with negative speed
    /// </summary>
    public void BackCommand(float distance, Action callback = null)
    {
        resetVelocity();

        m_back = true;
        m_distance = distance;
        m_onFinishMove = callback;
    }

    /// <summary>
    /// Reset the velocity of this object to zero
    /// </summary>
    private void resetVelocity()
    {
        m_rigidbody.velocity = Vector3.zero;
        m_time = 0;
        m_ahead = false;
        m_back = false;
    }


}
