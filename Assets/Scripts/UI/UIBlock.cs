using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class UIBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 m_startPos;
    private CanvasGroup m_canvasGroup;
    private EditModeController m_editController;

    void Awake()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();

        m_editController = FindObjectOfType<EditModeController>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Lógica se o bloco está no panel de blocos para se usar
        if (transform.parent == m_editController.ToUseTransform)
        {
            m_startPos = transform.position;

            m_canvasGroup.blocksRaycasts = false;
        }//Lógica se o bloco está no panel de blocos usados
        else
        {
            
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_canvasGroup.blocksRaycasts = true;

        if (transform.parent == m_editController.ToUseTransform)
        {

        }
        else
        {
            if (transform.parent != m_editController.UsedBlocksTransform)
            {
                transform.position = m_startPos;
                return;
            }

            //Create a copy of this object on the toUseBlocks list
            GameObject go = (GameObject)Instantiate(gameObject, m_startPos, Quaternion.identity);
            go.transform.SetParent(m_editController.ToUseTransform);
        }

        
    }
}
