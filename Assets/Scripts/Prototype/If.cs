using UnityEngine;
using System.Collections.Generic;
using System;

public class If : IBlock
{
    public bool condicao;

    public void Initialize()
    {
        
    }

    public void OnEndRunning()
    {
        
    }

    public void Run(Action callback)
    {
        //Antes de rodar a ação do if, verificar se a condição dele é verdadeira (mas onde?)
        if (condicao)
        {
            
        }
    }
}
