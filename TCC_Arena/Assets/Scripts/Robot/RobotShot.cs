using UnityEngine;
using System.Collections;
using System;

public class RobotShot : MonoBehaviour
{

    public GameObject shotPrefab;
    public Transform shotTransform;
    public float cooldownTime;

    private Action m_callback;

    public void ShootCommand(float speed, Action onFinish)
    {
        m_callback = onFinish;

        var shot = (GameObject)Instantiate(shotPrefab, shotTransform.position, Quaternion.identity);
        ShotInfo info = shot.GetComponent<ShotInfo>();
        info.SetInfo(speed);

        Invoke("finishCooldownTime", cooldownTime);
    }

    private void finishCooldownTime()
    {
        if (m_callback != null)
        {
            m_callback.Invoke();
        }
    }


}
