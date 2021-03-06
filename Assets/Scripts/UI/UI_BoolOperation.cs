﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_BoolOperation : MonoBehaviour, IDropHandler
{
    public UI_IfBlock conditionalBlock;

    private HorizontalLayoutGroup m_horizontalGroup;
    private List<UI_LogicalOperation> m_logicalOperations;
    private UI_RelationalOperation m_relationalOp;
    
    protected void Awake()
    {
        m_horizontalGroup = GetComponent<HorizontalLayoutGroup>();
        m_logicalOperations = new List<UI_LogicalOperation>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        UI_LogicalOperation logicalBlock = eventData.pointerDrag.GetComponent<UI_LogicalOperation>();

        if (logicalBlock != null)
        {
            m_relationalOp = null;

            m_logicalOperations.Add(logicalBlock);
            logicalBlock.transform.SetParent(m_horizontalGroup.transform);
            logicalBlock.DropValid = true;
        }

        UI_RelationalOperation relationalOp = eventData.pointerDrag.GetComponent<UI_RelationalOperation>();

        if (relationalOp != null)
        {
            //Significa que já há pelo menos 1 bloco lógico aqui
            if (m_logicalOperations.Count > 0)
                return;

            m_relationalOp = relationalOp;
            relationalOp.transform.SetParent(m_horizontalGroup.transform);
            relationalOp.DropValid = true;
        };
    }

    public BoolOperation GetBoolOperation()
    {
        List<LogicalOperation> logicalOps = new List<LogicalOperation>();

        m_logicalOperations.ForEach(x => logicalOps.Add(x.GetLogicalOperation()));

        return new BoolOperation(logicalOps, m_relationalOp.GetRelationalOperation());
    }
}
