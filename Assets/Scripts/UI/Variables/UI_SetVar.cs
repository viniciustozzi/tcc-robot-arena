using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UI_SetVar : UIBlock
{
    public Dropdown drop_var;
    public InputField input_value;

    void Start()
    {
        fillVariablesDropdown();
    }

    protected override AbstractBlock SetupBlockInfo()
    {
        var setVar = Controller.Instance.CURRENT_ROBOT.AddComponent<SetVariable>();
        setVar.VarName = drop_var.itemText.text;
        setVar.Value = input_value.text;
        return setVar;
    }

    private void fillVariablesDropdown()
    {
        drop_var.ClearOptions();

        List<Dropdown.OptionData> varOptions = new List<Dropdown.OptionData>();

        foreach (var variable in VariableController.Variables)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(variable.Key);
            varOptions.Add(option);
        }

        drop_var.AddOptions(varOptions);
    }
}
