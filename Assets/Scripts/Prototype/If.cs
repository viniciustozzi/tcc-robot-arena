using UnityEngine;
using System.Collections.Generic;
using System;

public class If : ExecuteCycle
{
    public bool condicao;

    public override void Initialize()
    {
        
    }
    
    public override void Run(Action callback)
    {
        //Antes de rodar a ação do if, verificar se a condição dele é verdadeira (mas onde?)
        if (condicao)
        {
            ExecuteBlock();
        }
    }

    public void OnEndRunning()
    {

    }
}
