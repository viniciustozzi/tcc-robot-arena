using UnityEngine;
using System;

public class Andar
{
	public float Distance;

	public void Initialize()
	{
		
	}

	public void Run(Action callback)
	{
		//Executar o monobehaviour de andar, callback deve ser passado para ele, e ele invoca
		Debug.Log("andou!");
		callback.Invoke();
	}

	
}
