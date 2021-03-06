﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UI_RelationalOperation : UIBlock
{
    public Dropdown drop_varA;
    public Dropdown drop_varB;
    public Dropdown drop_operationType;

    private RelationalOperation m_currentExpression;

    void Start()
    {
        drop_varA.ClearOptions();
        drop_varB.ClearOptions();
        drop_operationType.ClearOptions();

        fillVariableInfo();
        fillOperatorsInfo();
    }

    /// <summary>
    /// Retorna a expressão relacional que deriva deste bloco no momento
    /// </summary>
    public RelationalOperation GetRelationalOperation()
    {
        RelationalOperator opType = (RelationalOperator)Enum.Parse(typeof(RelationalOperator), drop_operationType.captionText.text);

        return new RelationalOperation(drop_varA.captionText.text, drop_varB.captionText.text, opType);
    }

    /// <summary>
    /// Adiiciona todos os operadores no dropdown list
    /// </summary>
    private void fillOperatorsInfo()
    {
        List<Dropdown.OptionData> operatorsOptions = new List<Dropdown.OptionData>();

        for (int i = 0; i < Enum.GetNames(typeof(RelationalOperator)).Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(GetOperatorPrettyName((RelationalOperator)i));
            operatorsOptions.Add(option);
        }

        drop_operationType.AddOptions(operatorsOptions);
    }

    /// <summary>
    /// Retorna o nome do operador que será apresentado para o usuário
    /// e não o que está definido no Enum
    /// </summary>
    private string GetOperatorPrettyName(RelationalOperator relOperator)
    {
        switch (relOperator)
        {
            case RelationalOperator.Bigger:  return "Maior";
            case RelationalOperator.BiggerAndEqual: return "Maior ou igual";
            case RelationalOperator.Equal: return "Igual";
            case RelationalOperator.LessAndEqual: return "Menor ou igual";
            case RelationalOperator.Less:  return "Menor";
        }

        Debug.LogWarning("Tipo de operador inválido recebido pelo método: GetOperatorPrettyName()");
        return string.Empty;
    }

    /// <summary>
    /// Adiciona no dropdown list todas as variáveis já declaradas pelo VariableManager
    /// </summary>
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
