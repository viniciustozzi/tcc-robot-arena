using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UsedBlocks : MonoBehaviour, IDropHandler
{
    private EditModeController m_editMode;

    void Awake()
    {
        m_editMode = FindObjectOfType<EditModeController>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        UIBlock blockComp = eventData.pointerDrag.GetComponent<UIBlock>();

        if (blockComp == null) return;

        //m_editMode.ResetBlocksToUse(blockComp.);

        //Debug.Log("Dropou: " + eventData.pointerDrag.name);

        blockComp.SetParent(transform);
    }

    public void OnExcludeButton()
    {

    }
}
