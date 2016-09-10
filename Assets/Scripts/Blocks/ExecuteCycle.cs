using UnityEngine;
using System.Collections.Generic;
using System;

public class ExecuteCycle : AbstractBlock
{
    public override List<AbstractBlock> LogicBlocks { get; set; }
    
    private Action m_callback;
    private int m_index;

    void Awake()
    {
        LogicBlocks = new List<AbstractBlock>();
    }

    public override void Initialize()
    {
        LogicBlocks.ForEach(x => x.Initialize());
    }

    public override void Run(Action blockCallback)
    {
        m_callback = blockCallback;

        if (LogicBlocks.Count <= 0)
        {
            m_callback.Invoke();
            return;
        }

        executeBlock();
    }

    private void executeBlock()
    {

        LogicBlocks[m_index].Run(_onExecuteBlock);
    }

    private void _onExecuteBlock()
    {
        m_index++;

        if (m_index >= LogicBlocks.Count)
            m_index = 0;

        executeBlock();
    }
}
