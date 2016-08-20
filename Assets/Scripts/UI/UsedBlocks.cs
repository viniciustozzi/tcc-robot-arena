using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UsedBlocks : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        UIBlock blockComp = eventData.pointerDrag.GetComponent<UIBlock>();

        if (blockComp == null) return;

        Debug.Log("Dropou: " + eventData.pointerDrag.name);

        blockComp.SetParent(transform);
    }

    public void OnExcludeButton()
    {

    }
}
