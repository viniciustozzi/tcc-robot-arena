using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {

    public float timeToDestroy;

    void Start()
    {
        Invoke("DestroyThis", timeToDestroy);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
