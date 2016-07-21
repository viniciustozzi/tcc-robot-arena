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

        try
        {
            //value1
        }
        catch (Exception e)
        {
            
            throw;
        }

        //switch (m_operationType)
        //{
        //    case BooleanOperator.Bigger:
        //        return m_var1.Value > m_var2.Value;
        //    case BooleanOperator.BiggerAndEqual:
        //        return m_var1 >= m_var2;
        //    case BooleanOperator.Equal:
        //        return m_var1 == m_var2;
        //    case BooleanOperator.LessAndEqual:
        //        return m_var1 <= m_var2;
        //    case BooleanOperator.Less:
        //        return m_var1 < m_var2;
        //}

        Debug.LogWarning("Expressão booleana não pode ser validada corretamente!");
        return false;
    }

    
}
