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
    private bool m_checkRaycast;

    //Posição atual da ponta do canhão, para saber a posição de inícios do raycast
    private Transform m_cannonTransform;

    void Awake()
    {
        LogicBlocks = new List<AbstractBlock>();
        m_robotAnalyser = FindObjectOfType<RobotAnalyser>();
        m_checkRaycast = true;

        m_cannonTransform = GetComponentInChildren<PosShot>().transform;
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
        m_checkRaycast = true;
        m_robotAnalyser.RunMainCycle();
    }

    public override void Stop()
    {

    }

    void Update()
    {
        if (m_checkRaycast)
        {
            Vector3 fwd = m_cannonTransform.TransformDirection(Vector3.forward);

            RaycastHit hit;

            //TODO: Vai cair sempre aqui, precisa criar uma flag pra verificar?
            if (Physics.Raycast(m_cannonTransform.position, fwd, out hit, 25))
            {
                if (hit.transform.tag == "Robot2")
                {
                    SendMessage("Stop", SendMessageOptions.DontRequireReceiver);
                    Run(_onRunAllBlocks);
                    m_checkRaycast = false;
                }
            }
        }
    }

    //Apenas desenha a visão do robô para debug (será válido mostrar isso para jogador?)
    void OnDrawGizmos()
    {
        Vector3 fwd = m_cannonTransform.TransformDirection(Vector3.forward);

        Debug.DrawLine(m_cannonTransform.position, m_cannonTransform.position + fwd * 25);
    }

}
