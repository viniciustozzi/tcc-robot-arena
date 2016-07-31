using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class While : MonoBehaviour, IBlock
{
    public List<IBlock> LogicBlocks;
    public BooleanExpression expression;
    private Action m_callback;

    private int m_index;

    public void Initialize()
    {
        m_index = 0;
    }

    public void Run(Action blockCallback)
    {
        m_callback = blockCallback;

        if (LogicBlocks.Count <= 0)
        {
            m_callback.Invoke();
            return;
        }

        if (expression.IsTrue())
            executeBlock();
    }

    private void executeBlock()
    {
        LogicBlocks[m_index].Run(()=>
            {
                m_index++;

                //Acabou todos blocos dentro desse if
                if (m_index >= LogicBlocks.Count)
                {
                    if (expression.IsTrue())
                    {
                        m_index = 0;
                        executeBlock();
                    }
                    else
                    {
                        m_index = 0;
                        Invoke("InvokeCallback", 0.5f);
                    }

                }
                else
                    executeBlock();
            });
    }

    private void InvokeCallback()
    {
        m_callback.Invoke();
    }
}
