using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ShotInfo : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    public void SetInfo(float speed, Transform sourceShooter)
    {
        m_rigidbody = GetComponent<Rigidbody>();

        m_rigidbody.velocity = sourceShooter.forward * speed;
    }
}