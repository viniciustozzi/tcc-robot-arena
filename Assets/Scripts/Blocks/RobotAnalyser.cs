using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RobotAnalyser : MonoBehaviour
{
    private GameObject m_robot;
    public GameObject prefab;

    void Start()
    {
        m_robot = new GameObject();

        addchild();

        m_robot.name = "ROBO";
        var rigidbody = m_robot.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;

        m_robot.AddComponent(typeof(ExecuteCycle));

        var executeComponent = m_robot.GetComponent<ExecuteCycle>();

        var moveAhead = m_robot.AddComponent<MoveAhead>();
        moveAhead.Distance = 20;

        VariableController.DeclareVariable("x", VariableType.Number, 1);
        VariableController.DeclareVariable("y", VariableType.Number, 3);

        var ifComponent = m_robot.AddComponent<If>();
        ifComponent.LogicBlocks = new List<IBlock>();
        ifComponent.condicao = new BooleanExpression("x", "y", BooleanOperator.Less);

        //var moveBack = m_robot.AddComponent<MoveBack>();
        //moveBack.Distance = 10;

        var whileComp = m_robot.AddComponent<While>();
        whileComp.LogicBlocks = new List<IBlock>();
        whileComp.expression = new BooleanExpression("x", "y", BooleanOperator.Less);
        var shotComp = m_robot.AddComponent<Shoot>();
        whileComp.LogicBlocks.Add(shotComp);

        //ifComponent.LogicBlocks.Add(moveBack);
        //executeComponent.LogicBlocks.Add(moveAhead);
        executeComponent.LogicBlocks.Add(ifComponent);
        executeComponent.LogicBlocks.Add(whileComp);

        executeComponent.Initialize();

        executeComponent.Run(metodoDeJesus);
    }

    private void metodoDeJesus()
    {
        Debug.Log("andou jesus");
    }

    private void addchild()
    {
        var go = (GameObject)GameObject.Instantiate(prefab, m_robot.transform.position, Quaternion.identity);
        go.transform.parent = m_robot.transform;
        go.transform.localPosition = new Vector3(0, 0, 0);
        go.transform.localScale = new Vector3(1, 1, 1);
    }
}
