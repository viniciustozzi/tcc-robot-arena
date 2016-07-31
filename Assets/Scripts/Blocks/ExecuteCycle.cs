using UnityEngine;
using System.Collections.Generic;
using System;

public class ExecuteCycle : MonoBehaviour, IBlock
{
    public List<IBlock> LogicBlocks { get; set; }

    private Action m_callback;
    private int m_index;

    void Awake()
    {
        LogicBlocks = new List<IBlock>();
    }

    public void Initialize()
    {
        LogicBlocks.ForEach(x => x.Initialize());
    }

    public void Run(Action blockCallback)
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
