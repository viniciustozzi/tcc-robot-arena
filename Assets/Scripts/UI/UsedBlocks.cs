using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UsedBlocks : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        GameObject goDragged = eventData.pointerDrag;

        goDragged.transform.SetParent(transform);
    }
}
