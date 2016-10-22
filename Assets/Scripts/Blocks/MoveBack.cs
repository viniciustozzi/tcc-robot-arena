using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MoveBack : AbstractBlock {

    private Action<bool> m_onFinishMove;
    private Rigidbody m_rigidbody;
    private float m_time;
    private bool m_move;
    private float m_speed = 10f;

    /// <summary>
    /// The distance that the robot will move
    /// </summary>
    public float Distance { get; set; }

    public override List<AbstractBlock> LogicBlocks { get; set; }

    void FixedUpdate()
    {
        if (m_move)
        {
            m_time += Time.deltaTime;

            if (m_time <= Distance / m_speed)
            {
                //Move o robo para tras
                m_rigidbody.velocity = transform.forward * -m_speed;
            }

            else
            {
                //Reseta a velocidade do robo para 0
                resetVelocity();

                //Já acbaou o movimento, chama o callback
                if (m_onFinishMove != null)
                {
                    IsRunning = false;
                    m_onFinishMove.Invoke(false);
                }
                    
            }
        }
    }

    public override void Initialize()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public override void Run(Action<bool> callback)
    {
        base.Run(callback);

        m_onFinishMove = callback;

        resetVelocity();
        m_move = true;
    }

    /// <summary>
    /// Reset the velocity of this object to zero
    /// </summary>
    private void resetVelocity()
    {
        m_rigidbody.velocity = Vector3.zero;
        m_time = 0;
        m_move = false;
    }

    public override void Stop()
    {
        if (!IsRunning) return;

        resetVelocity();
        m_onFinishMove.Invoke(true);

        base.Stop();
    }
}