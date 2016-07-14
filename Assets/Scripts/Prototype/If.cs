using System.Collections.Generic;
using UnityEngine;
using System;

public class If : MonoBehaviour, IBlock
{
    public bool condicao;

    private Action m_callback;

    public List<IBlock> LogicBlocks { get; set; }

    public void Initialize()
    {
        
    }

    public void Run(Action callback)
    {
        m_callback = callback;
    }

    private void onRunAllList()
    {
        //No caso do if, deve rodar a lista apenas uma vez, portanto:
        if (_runAllBlock != null)
            _runAllBlock.Invoke();
    }
}
