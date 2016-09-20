using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Variable : UIBlock
{
    public Text varName;
    
    public void SetVarName(string name)
    {
        varName.text = name;
    }
}
