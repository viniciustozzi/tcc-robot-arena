﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class OnWallCollisionCycle : AbstractBlock
{
    public override List<AbstractBlock> LogicBlocks { get; set; }

    private Action<bool> m_callback;

    private int m_index;

    void Awake()
    {
        LogicBlocks = new List<AbstractBlock>();
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
            m_index = 0;

        executeBlock();
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.tag == "Wall")
        {
            SendMessage("StopExecution", SendMessageOptions.DontRequireReceiver);

            Run(_onRunAllBlocks);
        }
    }

    /// <summary>
    /// Fim da execução de todos os blocos de colisão
    /// </summary>
    private void _onRunAllBlocks(bool interrupt)
    {
        
    }

    public override void Stop()
    {
        throw new NotImplementedException();
    }
}