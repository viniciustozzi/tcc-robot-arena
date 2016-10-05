﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class ExecuteCycle : AbstractBlock
{
    public override List<AbstractBlock> LogicBlocks { get; set; }

    private Action m_mainCallback;

    private int m_mainIndex;

    void Awake()
    {
        LogicBlocks = new List<AbstractBlock>();
    }

    public override void Initialize()
    {
        LogicBlocks.ForEach(x => x.Initialize());
    }

    public override void Run(Action blockCallback)
    {
        m_mainCallback = blockCallback;

        if (LogicBlocks.Count <= 0)
        {
            m_mainCallback.Invoke();
            return;
        }

        executeMainBlock();
    }

    private void executeMainBlock()
    {
        LogicBlocks[m_mainIndex].Run(_onExecuteMainBlock);
    }

    private void _onExecuteMainBlock()
    {
        m_mainIndex++;

        if (m_mainIndex >= LogicBlocks.Count)
            m_mainIndex = 0;

        executeMainBlock();
    }
}
