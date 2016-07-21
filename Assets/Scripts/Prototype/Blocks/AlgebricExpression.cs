using UnityEngine;
using System.Collections;

public class AlgebricExpression
{
    private float m_var1;
    private float m_var2;
    private AlgebricOperator m_operationType;

    public AlgebricExpression(float var1, float var2, AlgebricOperator opType)
    {
        m_operationType = opType;
    }

    public float Result()
    {
        return 0;
    }
}
