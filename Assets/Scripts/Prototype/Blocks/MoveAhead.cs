using UnityEngine;
using System.Collections;
using System;

public class MoveAhead : ExecuteCycle
{
    private Action m_onFinishMove;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Run(Action callback)
    {
        m_onFinishMove = callback;
    }
}
