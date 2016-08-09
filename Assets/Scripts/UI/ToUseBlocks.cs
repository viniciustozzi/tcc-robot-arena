using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ToUseBlocks : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        GameObject goDragged = eventData.pointerDrag;

        goDragged.transform.SetParent(transform);
    }
}
