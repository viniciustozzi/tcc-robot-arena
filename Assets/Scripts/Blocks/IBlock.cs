using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class AbstractBlock : MonoBehaviour
{
	public abstract void Initialize();
	
	public abstract void Run(Action blockCallback);

    public abstract List<AbstractBlock> LogicBlocks { get; set; }
}
