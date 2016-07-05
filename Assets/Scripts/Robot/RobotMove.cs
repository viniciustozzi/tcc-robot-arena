using UnityEngine;
using System.Collections;
using System;

public class RobotMove : MonoBehaviour
{
    public Rigidbody m_rigidbody;
    public float speed;

    private bool m_ahead;
    private bool m_back;
    private float m_time;
    private float m_distance;

    private Action m_onFinishMove;

    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
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
                m_rigidbody.velocity = transform.forward * speed;
            else if (m_back)
                m_rigidbody.velocity = transform.forward * -speed;
        }

        else
        {
            resetVelocity();
            
            if (m_onFinishMove != null)
            {
                m_onFinishMove.Invoke();
            }
        }
    }

	public void SetParameter(object value)
	{
		float.TryParse(value.ToString(), out m_distance);
	}

    /// <summary>
    /// Move the robot in the z-axis with positive speed
    /// </summary>
	public void AheadCommand(Action callback = null)
    {
        resetVelocity();

        m_ahead = true;
        m_onFinishMove = callback;
    }

    /// <summary>
    /// Move the robot in the z-axis with negative speed
    /// </summary>
    public void BackCommand(Action callback = null)
    {
        resetVelocity();

        m_back = true;
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
