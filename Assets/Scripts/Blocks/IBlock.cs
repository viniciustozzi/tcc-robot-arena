using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class AbstractBlock : MonoBehaviour
{
	public abstract void Initialize();
	
	public virtual void Run(Action<bool> blockCallback)
    {
        //Adicionar o componente stop
    }

    public abstract List<AbstractBlock> LogicBlocks { get; set; }

    public abstract void Stop();
}
