using System.Collections.Generic;
using UnityEngine;
using System;

public class If : MonoBehaviour, IBlock
{
    public BooleanExpression condicao;

    private Action m_callback;

    public List<IBlock> LogicBlocks { get; set; }

	private int m_index;

    void Awake()
    {
        LogicBlocks = new List<IBlock>();
    }

    public void Initialize()
    {
		m_index = 0;

        LogicBlocks.ForEach(x => x.Initialize());
    }

    public void Run(Action callback)
    {
        m_callback = callback;
        m_index = 0;
        
        if (LogicBlocks.Count <= 0)
        {
            m_callback.Invoke();
            return;
        }

        if (condicao.IsTrue())
            executeBlock();
        else
        {
            Invoke("InvokeCallback", 0.5f);
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
