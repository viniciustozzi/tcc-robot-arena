using UnityEngine;
using System.Collections.Generic;
using System;

public class ExecuteCycle : MonoBehaviour, IBlock
{
    private int m_index;

    //Callback executado quando termina de executar uma vez a lista de blocos lógicos
    public Action listRunCallback;

    public Action _runAllBlock;

    //protected void ExecuteBlock()
    //{
    //    LogicBlocks[m_index].Run(OnEndRunning);
    //}

    //protected void OnEndRunning()
    //{
    //    m_index++;

    //    ExecuteBlock();

    //    if (m_index >= LogicBlocks.Count - 1)
    //    {
    //        if (listRunCallback != null)
    //            listRunCallback.Invoke();
    //    }
    //}
    
    /// <summary>
    /// Executa o comando desse bloco
    /// </summary>
    /// <param name="callback">callback de quando o bloco termina de executar por completo</param>
    public virtual void Run(Action callback) { }

    public virtual void Initialize()
    {

    }
}
