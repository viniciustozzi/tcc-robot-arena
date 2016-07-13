using UnityEngine;
using System.Collections.Generic;
using System;

public class ExecuteCycle : MonoBehaviour, IBlock
{
    public List<IBlock> LogicBlocks { get; set; }

    private int m_index;

    protected Action m_callback;
    
    protected void ExecuteBlock()
    {
        LogicBlocks[m_index].Run(OnEndRunning);
    }

    protected void OnEndRunning()
    {
        m_index++;

        ExecuteBlock();

        if (m_index >= LogicBlocks.Count - 1)
        {
            if (m_callback != null)
                m_callback.Invoke();
        }
    }

    public virtual void Initialize() { }

    public virtual void Run(Action callback) { }
}
