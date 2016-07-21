using UnityEngine;
using System.Collections.Generic;
using System;

public class ExecuteCycle : MonoBehaviour, IBlock
{
    public List<IBlock> LogicBlocks { get; set; }

    private Action m_callback;
    private int m_index;

    void Start()
    {
        LogicBlocks = new List<IBlock>();
    }

    public void Initialize()
    {
        
    }

    public void Run(Action blockCallback)
    {
        m_callback = blockCallback;

        executeBlock();
    }

    private void executeBlock()
    {
        LogicBlocks[m_index].Run(()=>
            {
                m_index++;

                if (m_index >= LogicBlocks.Count)
                    m_index = 0;

                executeBlock();
            });
    }
    
}
