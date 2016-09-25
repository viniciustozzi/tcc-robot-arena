using System.Collections.Generic;
using UnityEngine;
using System;

public class If : AbstractBlock
{
    public BoolOperation condition;

    private Action m_callback;

    public override List<AbstractBlock> LogicBlocks { get; set; }

	private int m_index;

    void Awake()
    {
        LogicBlocks = new List<AbstractBlock>();
    }

    public override void Initialize()
    {
		m_index = 0;

        LogicBlocks.ForEach(x => x.Initialize());
    }

    public override void Run(Action callback)
    {
        m_callback = callback;
        m_index = 0;
        
        if (LogicBlocks.Count <= 0)
        {
            m_callback.Invoke();
            return;
        }

        if (condition.IsTrue())
            executeBlock();
        else
        {
            m_callback.Invoke();
        }       
    }
    
    private void InvokeCallback()
    {
        m_callback.Invoke();
    }


    private void executeBlock()
	{
		LogicBlocks[m_index].Run(_onFinishExecute);
	}

    private void _onFinishExecute()
    {
        m_index++;

        //Acabou todos blocos dentro desse if
        if (m_index >= LogicBlocks.Count)
            m_callback.Invoke();
        else
            executeBlock();
    }
}
