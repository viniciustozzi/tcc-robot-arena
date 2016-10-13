using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class While : AbstractBlock
{
    public BoolOperation expression;
    private Action<bool> m_callback;

    private int m_index;

    public override List<AbstractBlock> LogicBlocks { get; set; }

    public override void Initialize()
    {
        m_index = 0;

        LogicBlocks.ForEach(x => x.Initialize());
    }

    public override void Run(Action<bool> blockCallback)
    {
        m_callback = blockCallback;

        if (LogicBlocks.Count <= 0)
        {
            m_callback.Invoke(true);
            return;
        }

        if (expression.IsTrue())
            executeBlock();
    }

    public override void Stop()
    {
        throw new NotImplementedException();
    }

    private void executeBlock()
    {
        LogicBlocks[m_index].Run((bool mudarDepois)=>
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
        m_callback.Invoke(true);
    }
}
