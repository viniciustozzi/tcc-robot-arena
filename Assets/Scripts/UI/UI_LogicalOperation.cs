using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class UI_LogicalOperation : UIBlock
{
    public RelationalOpSpace opSpace1;
    public RelationalOpSpace opSpace2;
    public Dropdown drop_opType;

    protected override void Awake()
    {
        setOperatorTypes();

        base.Awake();
    }

    /// <summary>
    /// Retorna a expressão lógica baseada nesse bloco
    /// </summary>
    public LogicalOperation GetLogicalOperation()
    {
        LogicalOperator opType = (LogicalOperator)Enum.Parse(typeof(LogicalOperator), drop_opType.captionText.text);
        RelationalOperation op1 = opSpace1.CurrentOp.GetRelationalOperation();
        RelationalOperation op2 = opSpace2.CurrentOp.GetRelationalOperation();
        
        return new LogicalOperation(op1, op2, opType);
    }

    //Adiciona todos os operadores lógicos no dropdownlist 
    private void setOperatorTypes()
    {
        drop_opType.ClearOptions();

        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        for (int i = 0; i < Enum.GetNames(typeof(LogicalOperator)).Length; i++)
        {
            Dropdown.OptionData op = new Dropdown.OptionData(getOperatorPrettyName((LogicalOperator)i));
            options.Add(op);
        }

        drop_opType.AddOptions(options);
    }

    private string getOperatorPrettyName(LogicalOperator logicalOperator)
    {
        switch (logicalOperator)
        {
            case LogicalOperator.And: return "E";
            case LogicalOperator.Or: return "OU";
        }

        Debug.LogWarning("Tipo de operador lógico inválido no método: getOperatorPrettyName()");
        return string.Empty;
    }
}
