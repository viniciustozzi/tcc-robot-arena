using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ShotInfo : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    public void SetInfo(float speed)
    {
        m_rigidbody = GetComponent<Rigidbody>();

        m_rigidbody.velocity = transform.forward * speed;
    }
}