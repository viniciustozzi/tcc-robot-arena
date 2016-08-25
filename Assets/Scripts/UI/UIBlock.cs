using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class UIBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, I_UIBlock
{
    public BlockCategory category;

    private Vector3 m_startPos;
    private CanvasGroup m_canvasGroup;
    private EditModeController m_editController;

    public virtual bool CanHaveBlocks { get; set; }

    public virtual List<UIBlock> UI_Blocks { get; set; }

    protected virtual void Awake()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();

        m_editController = FindObjectOfType<EditModeController>();

        UI_Blocks = new List<UIBlock>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_startPos = transform.position;
        m_canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// If a UIBlock is dropped inside a UIBlock, it must be treated to add this UIblock if is possivel
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        var block = eventData.pointerDrag.GetComponent<UIBlock>();

        if (block == null) return;

        if (CanHaveBlocks)
        {
            AddToList(block);
        }
    }

    public void AddToList(UIBlock block)
    {
        UI_Blocks.Add(block);
        block.transform.SetParent(transform);
        block.transform.Reset();

        block.transform.position = new Vector2(transform.position.x + 30, transform.position.y - 40 * UI_Blocks.Count);

    }

}

public interface I_UIBlock
{
    bool CanHaveBlocks { get; set; }
    List<UIBlock> UI_Blocks { get; set; }
}