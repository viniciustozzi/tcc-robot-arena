using UnityEngine;
using System.Collections;
using System;

public interface IBlock
{
	void Initialize();
	
	void Run(Action callback);

	
}
