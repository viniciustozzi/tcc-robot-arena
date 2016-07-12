using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ExecuteCycle : MonoBehaviour, IBlock
{
    public List<IBlock> LogicBlocks { get; set; }

    private int m_index;

    private Action m_callback;
    
    protected void ExecuteBlock()
    {
        LogicBlocks[m_index].Run(OnEndRunning);
    }

    protected void OnEndRunning()
    {
        m_index++;

        if (m_index >= LogicBlocks.Count)
        {
            if (m_callback != null)
                m_callback.Invoke();
        }

        ExecuteBlock();
    }

    public virtual void Initialize() { }

    public virtual void Run(Action callback) { }
}
