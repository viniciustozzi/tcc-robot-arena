using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class UIBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, I_UIBlock
{
    private Vector3 m_startPos;
    private CanvasGroup m_canvasGroup;
    private EditModeController m_editController;
    private static bool m_droppedOnBlock;


    //public BlockPanel CurrentState { get; set; }

    public virtual bool CanHaveBlocks { get { return false; } }

    public virtual List<UIBlock> UI_Blocks { get { return null; } }

    protected virtual void Awake()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();

        m_editController = FindObjectOfType<EditModeController>();

        //CurrentState = BlockPanel.AvaibleBLocks;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_startPos = transform.position;

        //switch (CurrentState)
        //{
        //    //Lógica se o bloco está no panel de blocos para se usar
        //    case BlockPanel.AvaibleBLocks:
        //        m_startPos = transform.position;
        //        break;
        //    //Lógica se o bloco está no panel de blocos usados
        //    case BlockPanel.Used:
        //        break;
        //}
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Se o drag acabou ao colocar um bloco dentro de outro bloco, deve executar sua própria lógica
        //if (m_droppedOnBlock)
        //{
        //    switch (CurrentState)
        //    {
        //        case BlockPanel.AvaibleBLocks:
        //            m_editController.UpdateBlocksToUse();

        //            CurrentState = BlockPanel.Used;
        //            break;

        //        case BlockPanel.Used:

        //            break;
        //    }

        //    m_droppedOnBlock = false;

        //    return;
        //}

        //switch (CurrentState)
        //{
        //    case BlockPanel.AvaibleBLocks:
        //        if (transform.parent != m_editController.UsedBlocksTransform)
        //        {
        //            transform.position = m_startPos;
        //            return;
        //        }

        //        m_editController.UpdateBlocksToUse();
        //        CurrentState = BlockPanel.Used;

        //        break;
        //    case BlockPanel.Used:
        //        if (transform.parent != m_editController.UsedBlocksTransform)
        //        {
        //            Destroy(gameObject);
        //        }
        //        break;
        //}
    }

    /// <summary>
    /// If a UIBlock is dropped inside a UIBlock, it must be treated to add this UIblock if is possivel
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        var block = eventData.pointerDrag.GetComponent<UIBlock>();

        if (block == null) return;

        //if (!block.CanHaveBlocks) return;

        //m_droppedOnBlock = true;

        //UI_Blocks.Add(block);

        //block.transform.SetParent(transform);
        //block.transform.Reset();
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }
}

public interface I_UIBlock
{
    bool CanHaveBlocks { get; }
    List<UIBlock> UI_Blocks { get; }
}