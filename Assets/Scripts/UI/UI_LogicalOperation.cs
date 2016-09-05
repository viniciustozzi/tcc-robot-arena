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

    public LogicalOperation GetLogicalOperation()
    {
        LogicalOperator opType = (LogicalOperator)Enum.Parse(typeof(LogicalOperator), drop_opType.captionText.text);
        RelationalOperation op1 = opSpace1.CurrentOp.GetRelationalOperation();
        RelationalOperation op2 = opSpace2.CurrentOp.GetRelationalOperation();
        
        return new LogicalOperation(op1, op2, opType);
    }

    private void setOperatorTypes()
    {
        drop_opType.ClearOptions();

        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        for (int i = 0; i < Enum.GetNames(typeof(LogicalOperator)).Length; i++)
        {
            Dropdown.OptionData op = new Dropdown.OptionData(Enum.GetName(typeof(LogicalOperator), i));
            options.Add(op);
        }

        drop_opType.AddOptions(options);
    }

    protected override void Awake()
    {
        setOperatorTypes();

        base.Awake();
    }
}
