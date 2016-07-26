using UnityEngine;
using System.Collections;
using System;

public class MoveAhead : MonoBehaviour, IBlock
{
    private Action m_onFinishMove;
    private Rigidbody m_rigidbody;
    private float m_time;
    private bool m_move;
    private float m_speed = 10f;

    /// <summary>
    /// The distance that the robot will move
    /// </summary>
    public float Distance { get; set; }

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (m_move)
        {
            m_time += Time.deltaTime;

            if (m_time <= Distance / m_speed)
            {
                //Move o robo para frente
                m_rigidbody.velocity = transform.forward * m_speed;
            }

            else
            {
                Debug.Log("Androu tudo que tinha que andar");

                //Reseta a velocidade do robo para 0
                resetVelocity();

                //Já acbaou o movimento, chama o callback
                if (m_onFinishMove != null)
                    m_onFinishMove.Invoke();
            }
        }
    }

    public void Initialize()
    {
        
    }

    public void Run(Action callback)
    {
        m_onFinishMove = callback;

        resetVelocity();
        m_move = true;
    }

    /// <summary>
    /// Reset the velocity of this object to zero
    /// </summary>
    private void resetVelocity()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        m_time = 0;
        m_move = false;
    }
}