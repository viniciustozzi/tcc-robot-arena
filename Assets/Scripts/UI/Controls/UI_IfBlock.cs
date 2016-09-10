﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UI_IfBlock : UIBlock
{
    public List<UI_BoolOperation> BooleanExpressions;

    protected override void Awake()
    {
        CanHaveBlocks = true;

        base.Awake();
    }

    protected override AbstractBlock SetupBlockInfo()
    {
        //GameObject go = new GameObject();
        //go.name = "If";
        //var ifComp = go.AddComponent<If>();

        throw new NotImplementedException();
    }
}
