using UnityEngine;
using System.Collections;
using System;

public class BooleanExpression
{
    private VariableInfo m_var1;
    private VariableInfo m_var2;
    private BooleanOperator m_operationType;

    public BooleanExpression(string var1Name, string var2Name, BooleanOperator opType)
    {
        m_var1 = VariableController.Variables[var1Name];
        m_var2 = VariableController.Variables[var2Name];

        m_operationType = opType;
    }

    /// <summary>
    /// Retorna verdadeiro se var1 operation var2
    /// </summary>
    /// <param name="onParseError">O parâmetro é convertido para inteiro, se houver erro nessa conversão, é invocado um callback de erro</param>
    public bool IsTrue(Action onParseError = null)
    {
        int value1 = 0;
        int value2 = 0;

        //Caso a conversão não seja possível, deve permitir que quem esteja chamando essa função tratar esse erro
        //try
        //{
        //    value1 = Convert.ToInt32(m_var1.Value);
        //    value2 = Convert.ToInt32(m_var2.Value);
        //}
        //catch (Exception e)
        //{
        //    if (onParseError != null)
        //        onParseError.Invoke();

        //    return false;
        //    throw;
        //}

        value1 = (int)m_var1.Value;
        value2 = (int)m_var2.Value;

        switch (m_operationType)
        {
            case BooleanOperator.Bigger:
                return value1 > value2;
            case BooleanOperator.BiggerAndEqual:
                return value1 >= value2;
            case BooleanOperator.Equal:
                return value1 == value2;
            case BooleanOperator.LessAndEqual:
                return value1 <= value2;
            case BooleanOperator.Less:
                return value1 < value2;
        }

        Debug.LogWarning("Expressão booleana não pode ser validada corretamente!");
        return false;
    }

    public override string ToString()
    {
        return m_var1.Value.ToString() + " " + m_operationType.ToString() + " " + m_var2.Value.ToString() + " = " + IsTrue().ToString();
    }
}
