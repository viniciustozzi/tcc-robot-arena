using UnityEngine;
using System.Collections;

public static class Extensions
{
    public static void Reset(this Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localScale = new Vector3(1, 1, 1);
    }
}
