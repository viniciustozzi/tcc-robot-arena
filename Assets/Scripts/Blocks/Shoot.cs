using UnityEngine;
using System;
using System.Collections.Generic;

public class Shoot : AbstractBlock
{
    private Transform m_shotTransform;

    private float m_cooldownTime;
    private float m_speed;
    private GameObject m_shotPrefab;
    private Action<bool> m_callback;

    public override List<AbstractBlock> LogicBlocks { get; set; }

    public override void Initialize()
    {
        m_speed = 30f;
        m_cooldownTime = 1.5f;

        LoadShotPrefab();

        m_shotTransform = GetComponentInChildren<PosShot>().transform;
    }

    public override void Run(Action<bool> blockCallback)
    {
        m_callback = blockCallback;

        ((GameObject)Instantiate(m_shotPrefab, m_shotTransform.position, Quaternion.identity)).GetComponent<ShotInfo>().SetInfo(m_speed, m_shotTransform);

        Invoke("finishCooldownTime", m_cooldownTime);
    }

    public void LoadShotPrefab()
    {
        m_shotPrefab = Resources.Load<GameObject>("Prefabs/ShotPrefab");
    }

    private void finishCooldownTime()
    {
        if (m_callback != null)
            m_callback.Invoke(false);
    }

    public override void Stop()
    {
        if (!IsRunning) return;

        m_callback.Invoke(true);

        base.Stop();
    }
}
