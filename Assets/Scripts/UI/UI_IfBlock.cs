﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class UI_IfBlock : UIBlock
{
    public Dropdown drop_varA;
    public Dropdown drop_varB;
    public Dropdown drop_operationType;

    private BooleanExpression m_currentExpression;

    void Start()
    {
        fillOperatorsInfo();
        fillVariableInfo();
    }

    public BooleanExpression GetBooleanExpression()
    {
        BooleanOperator opType = (BooleanOperator)Enum.Parse(typeof(BooleanOperator), drop_operationType.captionText.text);

        return new BooleanExpression(drop_varA.captionText.text, drop_varB.captionText.text, opType);
    }

    private void fillOperatorsInfo()
    {
        List<Dropdown.OptionData> operatorsOptions = new List<Dropdown.OptionData>();

        for (int i = 0; i < Enum.GetNames(typeof(BooleanOperator)).Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(Enum.GetName(typeof(BooleanOperator), i));
            operatorsOptions.Add(option);
        }
    }

    private void fillVariableInfo()
    {
        List<Dropdown.OptionData> variableOptions = new List<Dropdown.OptionData>();

        foreach (var variable in VariableController.Variables)
        {
            //Cria uma nova opção com o nome da variável que foi definida anteriormente
            Dropdown.OptionData option = new Dropdown.OptionData(variable.Key);
            variableOptions.Add(option);
        }

        drop_varA.AddOptions(variableOptions);
        drop_varB.AddOptions(variableOptions);
    }
}
