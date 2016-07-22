using System.Collections.Generic;
using UnityEngine;
using System;

public class RobotAnalyser : MonoBehaviour
{
    private GameObject m_robot;

	void Start()
	{
        m_robot = new GameObject();
        m_robot.name = "ROBO";
        var rigidbody = m_robot.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        m_robot.AddComponent(typeof(ExecuteCycle));

        var executeComponent = m_robot.GetComponent<ExecuteCycle>();
//        executeComponent.LogicBlocks.Add(new MoveAhead() { Distance = 10f } );

        m_robot.AddComponent<MoveAhead>();
        var moveAhead = m_robot.GetComponent<MoveAhead>();
        moveAhead.Distance = 2;

        executeComponent.Initialize();
        executeComponent.LogicBlocks.Add(moveAhead);

        executeComponent.Run(() => Debug.Log("andou jesus"));
	}
}
