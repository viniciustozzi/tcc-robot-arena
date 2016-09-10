using UnityEngine;
using System;
using System.Collections.Generic;

public class Shoot : AbstractBlock
{
    public Transform shotTransform;

    private float m_cooldownTime;
    private float m_speed;
    private GameObject m_shotPrefab;
    private Action m_callback;

    public override List<AbstractBlock> LogicBlocks { get; set; }

    public override void Initialize()
    {
        LoadShotPrefab();

        m_speed = 30f;
        m_cooldownTime = 1.5f;
    }

    public override void Run(Action blockCallback)
    {
        m_callback = blockCallback;

        ((GameObject)Instantiate(m_shotPrefab, shotTransform.position, Quaternion.identity)).GetComponent<ShotInfo>().SetInfo(m_speed);

        Invoke("finishCooldownTime", m_cooldownTime);
    }

    public void LoadShotPrefab()
    {
        m_shotPrefab = Resources.Load<GameObject>("Prefabs/RobotShot");
    }

    private void finishCooldownTime()
    {
        if (m_callback != null)
            m_callback.Invoke();
    }

}
