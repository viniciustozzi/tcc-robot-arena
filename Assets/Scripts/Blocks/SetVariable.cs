using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SetVariable : AbstractBlock
{
    public override List<AbstractBlock> LogicBlocks { get; set; }

    public string VarName { get; set; }

    //O valor é recebido como string mas precisa ser tratado se é numérico, string ou booleana
    public string Value { get; set; }

    public override void Initialize()
    {
        
    }

    public override void Run(Action blockCallback)
    {
        //TODO:  Tratar o tipo da variável!!!
        VariableController.SetValue(VarName, Value);
    }
}
