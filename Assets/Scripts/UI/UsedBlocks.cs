using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UsedBlocks : MonoBehaviour, IDropHandler
{
    public Transform contentScroll;
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
        
        //O bloco veio de dentro de outro bloco?
        if (blockComp.FromWhere == ComeFromWhere.InsideBlock)
        {
            //Remove o bloco de dentro do bloco de onde ele veio (exemplo: MoveAhead dentro de um While)
            blockComp.LastParent.RemoveFromList(blockComp);
        }

        blockComp.FromWhere = ComeFromWhere.UsedBlocks;
        
        blockComp.transform.SetParent(contentScroll.transform);

        m_editMode.ResetBlocksToUse(blockComp.category);
    }

    public void OnExcludeButton(UIBlock block)
    {
        var lastParent = block.LastParent;

        //Caso esse bloco esteja atrelado a algum bloco pai (dentro de outro bloco)
        if (lastParent != null)
        {
            //Deve remover esse bloco da lista do pai
            block.LastParent.RemoveFromList(block);
        }   

        Destroy(block.gameObject);
    }
}
