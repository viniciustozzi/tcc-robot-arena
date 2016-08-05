using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class UIBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private ToUseBlocks pnl_toUseBlocks;
    private UsedBlocks pnl_usedBlocks;
    private bool m_beingUsed;
    private Vector3 m_startPos;

    public static GameObject ItemBeingDragged;

    void Awake()
    {
        pnl_toUseBlocks = FindObjectOfType<ToUseBlocks>();
        pnl_usedBlocks = FindObjectOfType<UsedBlocks>();
    }

    public void AddBlock()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_startPos = transform.position;
        ItemBeingDragged = gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ItemBeingDragged = null;
        transform.position = m_startPos;
    }
}
