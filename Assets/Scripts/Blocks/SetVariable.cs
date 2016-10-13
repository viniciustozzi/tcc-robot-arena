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

    public override void Run(Action<bool> blockCallback)
    {

        VariableInfo varInfo = VariableController.Variables[VarName];

        switch (varInfo.Type)
        {
            case VariableType.Number:
                float floatValue = 0;
                if (!float.TryParse(Value, out floatValue))
                    Debug.LogWarning("Não foi possível converter o valor para float na hora de setar a variável!");

                VariableController.SetValue(VarName, (float)floatValue);

                break;
            case VariableType.String:

                VariableController.SetValue(VarName, Value);

                break;
            case VariableType.Bool:

                bool boolValue = false;
                if (!bool.TryParse(Value, out boolValue))
                    Debug.LogWarning("Não foi possível converter o valor para bool na hora de setar a variável!");

                VariableController.SetValue(VarName, (bool)boolValue);

                break;
        }
    }

    public override void Stop()
    {
        throw new NotImplementedException();
    }
}
