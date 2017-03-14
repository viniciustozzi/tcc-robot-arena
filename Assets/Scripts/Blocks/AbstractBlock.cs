using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class AbstractBlock : MonoBehaviour
{
    /// <summary>
    /// Inicializa variáveis e configurações desse bloco caso seja necessário
    /// </summary>
	public abstract void Initialize();

    /// <summary>
    /// Executa a ação desse bloco, recebe o método a ser executado quando a ação acabar
    /// </summary>
    public virtual void Run(Action<bool> blockCallback)
    {
        IsRunning = true;
    }

    /// <summary>
    /// Lista de blocos que esse bloco possui dentro dele, caso seja possível
    /// </summary>
    public abstract List<AbstractBlock> LogicBlocks { get; set; }

    /// <summary>
    /// Para a execução do bloco e execução atual
    /// </summary>
    public virtual void Stop()
    {
        IsRunning = false;
    }

    /// <summary>
    /// Se é o bloco que está sendo executado 
    /// </summary>
    public bool IsRunning { get; set; }
}
