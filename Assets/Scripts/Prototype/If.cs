using System.Collections.Generic;
using UnityEngine;
using System;

public class If : MonoBehaviour, IBlock
{
    public BooleanExpression condicao;

    private Action m_callback;

    public List<IBlock> LogicBlocks { get; set; }

	private int m_index;

    public void Initialize()
    {
		m_index = 0;
    }

    public void Run(Action callback)
    {
        m_callback = callback;

		if (condicao.IsTrue())
			executeBlock();
    }

	private void executeBlock()
	{
		LogicBlocks[m_index].Run(()=>
			{
				m_index++;

				//Acabou todos blocos dentro desse if
				if (m_index >= LogicBlocks.Count)
					m_callback.Invoke();
				else
					executeBlock();
			});
	}
}
