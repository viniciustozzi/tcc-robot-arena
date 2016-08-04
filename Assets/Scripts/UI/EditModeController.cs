using UnityEngine;
using System.Collections.Generic;

public class EditModeController : MonoBehaviour {

    public List<UIBlock> UIBlocks;

	void Awake()
    {
        //Criação de variaveis para testes:
        VariableController.DeclareVariable("x", VariableType.Number, 3);
        VariableController.DeclareVariable("y", VariableType.Number, 1);

        //Invoke("teste", 1f);
    }
}
