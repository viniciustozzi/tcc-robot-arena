using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class RelationalOpSpace : MonoBehaviour, IDropHandler
{
    public UI_RelationalOperation CurrentOp { get; set; }

    private HorizontalLayoutGroup m_horizontalGroup;

    void Awake()
    {
        m_horizontalGroup = GetComponent<HorizontalLayoutGroup>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        UI_RelationalOperation op = eventData.pointerDrag.GetComponent<UI_RelationalOperation>();

        if (op != null)
        {
            CurrentOp = op;
            op.transform.SetParent(m_horizontalGroup.transform);
            op.transform.Reset();
        }
    }
}
