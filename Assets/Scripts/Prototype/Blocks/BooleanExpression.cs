using UnityEngine;
using System.Collections;
using System;

public class BooleanExpression
{
	private float m_var1;
	private float m_var2;

	public BooleanExpression(float var1, float var2)
	{
		m_var1 = var1;
		m_var2 = var2;
	}

    public BooleanOperator operationType;

    //TODO: Alterar para funcionar com variáveis e não com valores fixos!!!

	/// <summary>
	/// Retorna verdadeiro se var1 operation var2
	/// </summary>
    public bool IsTrue()
    {
		switch (operationType) 
		{
			case BooleanOperator.Bigger:
				return m_var1 > m_var2;
			case BooleanOperator.BiggerAndEqual:
				return m_var1 >= m_var2;
			case BooleanOperator.Equal:
				return m_var1 == m_var2;
			case BooleanOperator.LessAndEqual:
				return m_var1 <= m_var2;
			case BooleanOperator.Less:
				return m_var1 < m_var2;
		}

		Debug.LogWarning("Expressão booleana não pode ser validada corretamente!");
		return false;
    }
}
