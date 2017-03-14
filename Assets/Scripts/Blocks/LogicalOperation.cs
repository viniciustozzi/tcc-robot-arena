using UnityEngine;
using System.Collections;

public class LogicalOperation
{
    private RelationalOperation m_op1;
    private RelationalOperation m_op2;
    private LogicalOperator m_opType;

    public LogicalOperation(RelationalOperation operation1, RelationalOperation operation2, LogicalOperator operatorType)
    {
        m_op1 = operation1;
        m_op2 = operation2;
        m_opType = operatorType;
    }

    public bool IsTrue()
    {
        switch (m_opType)
        {
            case LogicalOperator.And:
                break;
            case LogicalOperator.Or:
                break;
        }

        Debug.LogWarning("");
        return false;
    }
}
