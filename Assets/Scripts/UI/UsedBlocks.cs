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

        blockComp.DropValid = true;

        blockComp.transform.SetParent(transform);

        m_editMode.ResetBlocksToUse(blockComp.category);
    }

    public void OnExcludeButton()
    {

    }
}
