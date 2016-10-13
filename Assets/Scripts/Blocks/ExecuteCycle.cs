using UnityEngine;
using System.Collections.Generic;
using System;

public class ExecuteCycle : AbstractBlock
{
    public override List<AbstractBlock> LogicBlocks { get; set; }

    private int m_mainIndex;

    void Awake()
    {
        LogicBlocks = new List<AbstractBlock>();
    }

    public override void Initialize()
    {
        LogicBlocks.ForEach(x => x.Initialize());
    }

    public override void Run(Action<bool> blockCallback)
    {
        if (LogicBlocks.Count <= 0)
        {
            blockCallback.Invoke(false);
            return;
        }

        executeMainBlock();
    }

    private void executeMainBlock()
    {
        LogicBlocks[m_mainIndex].Run(_onExecuteMainBlock);
    }

    //Se stop cycle foi recebido como true significa que foi interrompido e deve parara execução desse ciclo
    private void _onExecuteMainBlock(bool stopCycle)
    {
        if (stopCycle)
        {
            return;
        }

        m_mainIndex++;

        if (m_mainIndex >= LogicBlocks.Count)
            m_mainIndex = 0;

        executeMainBlock();
    }

    public override void Stop()
    {

    }
}
