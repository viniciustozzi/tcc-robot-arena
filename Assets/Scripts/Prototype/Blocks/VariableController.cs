using UnityEngine;
using System.Collections.Generic;

public static class VariableController
{
    /// <summary>
    /// All variables existing that are defined by the user
    /// </summary>
    public static Dictionary<string, VariableInfo> Variables = new Dictionary<string, VariableInfo>();

    public static void DeclareVariable(string name, VariableType type, object value)
    {
        VariableInfo varInfo = new VariableInfo()
        {
            Type = type,
            Value = value
        };

        Variables.Add(name, varInfo);
    }

    public static void SetValue(string varName, object value)
    {
        Variables[varName].Value = value;
    }

    public static object GetValue(string varName)
    {
        return Variables[varName];
    }
}

public class VariableInfo
{
    public VariableType Type { get; set; }
    public object Value { get; set; }
}