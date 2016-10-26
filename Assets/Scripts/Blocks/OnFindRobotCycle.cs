using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class OnFindRobotCycle : AbstractBlock
{
    public override List<AbstractBlock> LogicBlocks { get; set; }

    private Action<bool> m_callback;
    private int m_index;
    private RobotAnalyser m_robotAnalyser;

    void Awake()
    {
        LogicBlocks = new List<AbstractBlock>();
        m_robotAnalyser = FindObjectOfType<RobotAnalyser>();
    }

    public override void Initialize()
    {
        LogicBlocks.ForEach(x => x.Initialize());
    }

    public override void Run(Action<bool> blockCallback)
    {
        m_callback = blockCallback;

        if (LogicBlocks.Count <= 0)
        {
            m_callback.Invoke(false);
            return;
        }

        executeBlock();
    }

    private void executeBlock()
    {
        LogicBlocks[m_index].Run(_onExecuteBlock);
    }

    private void _onExecuteBlock(bool interrupt)
    {
        m_index++;

        if (m_index >= LogicBlocks.Count)
        {
            Invoke("InvokeCallback", 0.1f);
            return;
        }

        executeBlock();
    }

    private void InvokeCallback()
    {
        m_callback.Invoke(false);
    }

    /// <summary>
    /// Fim da execução de todos os blocos de detecção de robô
    /// </summary>
    private void _onRunAllBlocks(bool interrupt)
    {
        m_index = 0;
        m_robotAnalyser.RunMainCycle();
    }

    public override void Stop()
    {

    }

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        Physics.Raycast(transform.position, fwd, out hit, 20);

        //TODO: Vai cair sempre aqui, precisa criar uma flag pra verificar?
        if (hit.transform.tag == "Robot2")
        {
            SendMessage("Stop", SendMessageOptions.DontRequireReceiver);

            Run(_onRunAllBlocks);
        }
    }

    //Apenas desenha a visão do robô para debug (será válido mostrar isso para jogador?)
    void OnDrawGizmos()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Gizmos.DrawLine(transform.position, transform.position + fwd * 20);
    }

}
