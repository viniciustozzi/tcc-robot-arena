﻿public enum AlgebricOperator
{
	Sum = 0,
	Subtract = 1,
	Multiply = 2,
	Division = 3
}

public enum RelationalOperator
{
	Bigger = 0,
	BiggerAndEqual = 1,
	Equal = 2,
	LessAndEqual = 3,
	Less = 4
}

public enum LogicalOperator
{
    And = 0,
    Or = 1
}

public enum VariableType
{
    Number = 0,
    String = 1,
    Bool = 2
}

public enum BlockPanel
{
    None = 0,
    AvaibleBLocks = 1,
    Used = 2
}

public enum BlockCategory
{
    RobotActions,
    Variables,
    Events,
    Operators,
    Controls
}

public enum ComeFromWhere
{
    None,
    ToUseBlocks,
    UsedBlocks,
    InsideBlock
}
