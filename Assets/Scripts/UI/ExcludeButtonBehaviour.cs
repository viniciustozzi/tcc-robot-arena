using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ExcludeButtonBehaviour : MonoBehaviour, IDropHandler
{
    private UsedBlocks m_usedBlocks;

    void Start()
    {
        m_usedBlocks = FindObjectOfType<UsedBlocks>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        UIBlock blockComp = eventData.pointerDrag.GetComponent<UIBlock>();

        if (blockComp == null) return;

        m_usedBlocks.OnExcludeButton();
    }
}
