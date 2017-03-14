using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoolOperation : MonoBehaviour
{
    private List<LogicalOperation> m_logicalOpList;
    private RelationalOperation m_relationalOp;

    public BoolOperation(List<LogicalOperation> logicalOps, RelationalOperation relationalOp)
    {
        m_logicalOpList = logicalOps;
        m_relationalOp = relationalOp;
    }

    public bool IsTrue()
    {
        if (m_logicalOpList.Count > 0)
        {
            int count = 0;

            foreach (LogicalOperation op in m_logicalOpList)
            {
                if (!op.IsTrue())
                    count++;
            }


            if (count <= 0)
                return true;
        }
        else
        {
            return m_relationalOp.IsTrue();
        }

        return false;
    }
}
