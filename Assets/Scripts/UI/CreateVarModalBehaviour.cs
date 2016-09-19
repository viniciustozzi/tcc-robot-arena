using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateVarModalBehaviour : MonoBehaviour
{
    public InputField input_nameVar;
    public InputField input_valueVar;
    public Dropdown drop_typeVar;

    private EditModeController m_editMode;

    void Start()
    {
        m_editMode = FindObjectOfType<EditModeController>();
    }

    public void ConfirmCreateClick()
    {
        string name = input_nameVar.text;
        var value = input_valueVar.text;
        var type = getVarType(drop_typeVar.value);

        VariableController.DeclareVariable(name, type, value);
        m_editMode.ResetBlocksToUse(BlockCategory.Variables);
        CloseModal();
    }

    private VariableType getVarType(int dropDownValue)
    {
        switch (dropDownValue)
        {
            case 0: return VariableType.Number;
            case 1: return VariableType.String;
            case 2: return VariableType.Bool;
        }

        Debug.LogWarning("Ocorreu um erro ao criar a variável, retornando tipo string pois é menos chance de travar");
        return VariableType.String;
    }

    public void CloseModal()
    {
        Destroy(gameObject);
    }
}
