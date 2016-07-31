using UnityEngine;
using System.Collections;
using System;

public class AlgebricExpression
{
    private VariableInfo m_var1;
    private VariableInfo m_var2;
    private AlgebricOperator m_operationType;

    public AlgebricExpression(string var1Name, string var2Name, AlgebricOperator opType)
    {
        m_var1 = VariableController.Variables[var1Name];
        m_var2 = VariableController.Variables[var2Name];

        m_operationType = opType;
    }

    public int Result(Action onParseError = null)
    {
        int value1 = 0;
        int value2 = 0;

        //Caso a conversão não seja possível, deve permitir que quem esteja chamando essa função tratar esse erro
        try
        {
            value1 = Convert.ToInt32(m_var1.Value);
            value2 = Convert.ToInt32(m_var2.Value);
        }
        catch (Exception e)
        {
            if (onParseError != null)
                onParseError.Invoke();

            throw;
            return 0;
        }

        switch (m_operationType)
        {
            case AlgebricOperator.Sum:
                return value1 + value2;
            case AlgebricOperator.Subtract:
                return value1 - value2;
            case AlgebricOperator.Multiply:
                return value1 * value2;
            case AlgebricOperator.Division:
                return value1 / value2;
        }

        Debug.LogWarning("Ocorreu algum erro ao efetuar operação algébrica");
        return 0;
    }
}
