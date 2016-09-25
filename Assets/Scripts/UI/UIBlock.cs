using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class UIBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public BlockCategory category;

    public bool CanHaveBlocks;
    public bool Draggable = true;

    public bool DropValid { get; set; }
    public ComeFromWhere FromWhere { get; set; }

    public virtual List<UIBlock> UI_Blocks { get; set; }
    public UIBlock LastParent { get; set; }

    protected AbstractBlock m_blockStructure;

    private Vector3 m_startPos;
    private CanvasGroup m_canvasGroup;
    private EditModeController m_editController;
    private Transform m_layoutGroup;

    protected virtual void Awake()
    {
        m_canvasGroup = GetComponent<CanvasGroup>();

        m_editController = FindObjectOfType<EditModeController>();

        UI_Blocks = new List<UIBlock>();

        FromWhere = ComeFromWhere.ToUseBlocks;

        getLayoutGroupReference();
    }

    //Guarda a referência do layout group se esse for um bloco que pode ter outros blocos dentro dele
    private void getLayoutGroupReference()
    {
        VerticalLayoutGroup group = transform.GetComponentInChildren<VerticalLayoutGroup>();

        if (group != null)
            m_layoutGroup = group.transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!Draggable) return;

        m_startPos = transform.position;
        m_canvasGroup.blocksRaycasts = false;
        DropValid = false;

        //Se no início do drag, esse bloco estiver dentro de outro bloco, 
        if (FromWhere == ComeFromWhere.InsideBlock)
            LastParent = transform.GetComponent<UIBlock>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!DropValid)
            transform.position = m_startPos;

        m_canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// If a UIBlock is dropped inside a UIBlock, it must be treated to add this UIblock if is possivel
    /// </summary>
    /// <param name="eventData"></param>
    public virtual void OnDrop(PointerEventData eventData)
    {
        DropValid = true;

        checkDropBlock(eventData);
    }

    //Se quem foi dropado nesse bloco foi um outro bloco simples (não operação relacional ou lógica)
    private void checkDropBlock(PointerEventData eventData)
    {
        var block = eventData.pointerDrag.GetComponent<UIBlock>();

        //Caso o bloco exista e não seja um operador relacional ou lógico (já que operadores são só parâmetros de If ou While)
        if (block != null && block.category != BlockCategory.Operators)
        {
            //O bloco veio de dentro de outro bloco?
            if (block.FromWhere == ComeFromWhere.InsideBlock)
            {
                //Remove o bloco de dentro do bloco de onde ele veio (exemplo: MoveAhead dentro de um While)
                block.LastParent.RemoveFromList(block);
            }

            //Esse bloco pode ter blocos dentro dele? (Se sim significa que é um If, While etc...
            if (CanHaveBlocks)
            {
                block.FromWhere = ComeFromWhere.InsideBlock;
                AddToList(block);
            }
        }

        Debug.Log("OnDrop: " + this.gameObject.name + " : " + UI_Blocks.Count);
    }

    private void addToVerticalLayout(Transform block)
    {
        block.SetParent(m_layoutGroup);
    }

    public void AddToList(UIBlock block)
    {
        UI_Blocks.Add(block);
        addToVerticalLayout(block.transform);
        block.transform.Reset();
    }

    public void RemoveFromList(UIBlock block)
    {
        UI_Blocks.Remove(block);
    }

    public AbstractBlock GetLogicBlockStructure()
    {
        AbstractBlock thisBlockStructure = getBlockInfo();

        if (CanHaveBlocks)
        {
            List<AbstractBlock> childrenBlocks = new List<AbstractBlock>();

            Debug.Log("GetLogiStructure:" + gameObject.name + " : " + UI_Blocks.Count);

            foreach (var uiBlock in UI_Blocks)
            {
                AbstractBlock childBlock = uiBlock.GetLogicBlockStructure();
                childrenBlocks.Add(childBlock);
            }

            thisBlockStructure.LogicBlocks.AddRange(childrenBlocks);
        }

        return thisBlockStructure;
    }

    private AbstractBlock getBlockInfo()
    {
        if (this is OnBegin)
            return ((OnBegin)this).SetupBlockInfo();
        else if (this is UI_MoveAhead)
            return ((UI_MoveAhead)this).SetupBlockInfo();
        else if (this is UI_MoveBack)
            return ((UI_MoveBack)this).SetupBlockInfo();
        else if (this is UI_RotateRobot)
            return ((UI_RotateRobot)this).SetupBlockInfo();
        else if (this is UI_RotateCannon)
            return ((UI_RotateCannon)this).SetupBlockInfo();
        else if (this is UI_Shoot)
            return ((UI_Shoot)this).SetupBlockInfo();
        else if (this is UI_IfBlock)
            return ((UI_IfBlock)this).SetupBlockInfo();
        else if (this is UI_WhileBlock)
            return ((UI_WhileBlock)this).SetupBlockInfo();
        else if (this is UI_WhileBlock)
            return ((UI_WhileBlock)this).SetupBlockInfo();

        return null;
    }

    protected virtual AbstractBlock SetupBlockInfo()
    {
        return null;
    }

}