using UnityEngine;
using System.Collections.Generic;
using System;

public class ExecuteCycle : AbstractBlock
{
    public override List<AbstractBlock> LogicBlocks { get; set; }

    //Lista de ações que o robô executará ao colidir com uma barreira
    public List<AbstractBlock> WallCollisionBlocks { get; set; }

    //Lista de ações que o robô executará ao detectar outro robô
    public List<AbstractBlock> OnDetectBlocks { get; set; }

    private Action m_mainCallback;
    private Action m_wallCallback;
    private Action m_onDetectCallback;

    private int m_mainIndex;
    private int m_wallIndex;
    private int m_detectIndex;

    void Awake()
    {
        LogicBlocks = new List<AbstractBlock>();
        WallCollisionBlocks = new List<AbstractBlock>();
        OnDetectBlocks = new List<AbstractBlock>();
    }

    public override void Initialize()
    {
        LogicBlocks.ForEach(x => x.Initialize());
        WallCollisionBlocks.ForEach(x => x.Initialize());
        OnDetectBlocks.ForEach(x => x.Initialize());
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

    void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.tag == "Wall")
        {
            SendMessage("StopExecution", SendMessageOptions.RequireReceiver);
            executeWallCollisionBlocks();
        }
    }

    private void executeWallCollisionBlocks()
    {
        WallCollisionBlocks[m_wallIndex].Run(_onExecuteWallBlock);
    }

    private void _onExecuteWallBlock()
    {
        m_wallIndex++;

        //Já rodous todos os blocos ao colidir com uma parede
        if (m_wallIndex >= WallCollisionBlocks.Count)
        {
            executeMainBlock();
            return;
        }

        executeWallCollisionBlocks();
    }
}
