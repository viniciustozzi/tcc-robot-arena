using System.Collections.Generic;
using System;

public class If : ExecuteCycle
{
    public bool condicao;

    private Action m_callback;

    public override void Initialize()
    {
        listRunCallback = onRunAllList;
    }

    public override void Run(Action callback)
    {
        m_callback = callback;

        //Antes de rodar a ação do if, verificar se a condição dele é verdadeira (mas onde?)
        if (condicao)
        {
            ExecuteBlock();
        }
    }

    private void onRunAllList()
    {
        //No caso do if, deve rodar a lista apenas uma vez, portanto:
        if (_runAllBlock != null)
            _runAllBlock.Invoke();
    }
}
