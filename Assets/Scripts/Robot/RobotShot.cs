using UnityEngine;
using System.Collections;
using System;

public class RobotShot : MonoBehaviour
{
    public GameObject shotPrefab;
    public Transform shotTransform;
    public float cooldownTime;
    public float speed;

    private Action m_callback;

    public void ShootCommand(Action onFinish)
    {
        m_callback = onFinish;

        ((GameObject)Instantiate(shotPrefab, shotTransform.position, Quaternion.identity)).GetComponent<ShotInfo>().SetInfo(speed, shotTransform);

        Invoke("finishCooldownTime", cooldownTime);
    }

    public void SetParameter(object x)
    {

    }

    private void finishCooldownTime()
    {
        if (m_callback != null)
        {
            m_callback.Invoke();
        }
    }
}
