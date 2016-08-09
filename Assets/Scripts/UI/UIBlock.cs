using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public enum BlockPanel
{
    None = 0,
    AvaibleBLocks = 1,
    Used = 2
}

public class UIBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, I_UIBlock
{
    private Vector3 m_startPos;
    private CanvasGroup m_canvasGroup;
    private EditModeController m_editController;

    private BlockPanel m_currentState;

    public virtual bool CanHaveBlocks { get { return false; } }

    public virtual List<UIBlock> UI_Blocks { get { return null; } }

    void Awake()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();

        m_editController = FindObjectOfType<EditModeController>();

        m_currentState = BlockPanel.AvaibleBLocks;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        switch (m_currentState)
        {
            //Lógica se o bloco está no panel de blocos para se usar
            case BlockPanel.AvaibleBLocks:
                m_startPos = transform.position;
                m_canvasGroup.blocksRaycasts = false;
                break;
            //Lógica se o bloco está no panel de blocos usados
            case BlockPanel.Used:
                break;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_canvasGroup.blocksRaycasts = true;

        switch (m_currentState)
        {
            case BlockPanel.AvaibleBLocks:
                if (transform.parent != m_editController.UsedBlocksTransform)
                {
                    transform.position = m_startPos;
                    return;
                }

                //Create a copy of this object on the toUseBlocks list
                GameObject go = (GameObject)Instantiate(gameObject, m_startPos, Quaternion.identity);
                go.transform.SetParent(m_editController.ToUseTransform);

                m_currentState = BlockPanel.Used;

                break;
            case BlockPanel.Used:
                if (transform.parent != m_editController.UsedBlocksTransform)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }

    /// <summary>
    /// If a UIBlock is dropped inside a UIBlock, it must be treated to add this UIblock if is possivel
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        var block = eventData.pointerDrag.GetComponent<UIBlock>();

        if (block == null) return;

        if (!block.CanHaveBlocks) return;

        //Tratar isso visualmente, acoplamento do bloco
        UI_Blocks.Add(block);
    }
}

public interface I_UIBlock
{
    bool CanHaveBlocks { get; }
    List<UIBlock> UI_Blocks { get; }
}