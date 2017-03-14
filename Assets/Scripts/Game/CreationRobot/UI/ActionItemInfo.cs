using System;

[Serializable]
public class ActionItemInfo
{
	public ActionType ActionType { get; set; }
    public ListActionType ListType {get; set; }
	public object Parameters { get; set;}
}

/*
[Serializable]
public class ExpressionActionInfo : ActionItemInfo
{
    public string condition;

    public ActionType ActionToExecute { get; set; }
}*/