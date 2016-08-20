using UnityEngine;
using System.Collections;

public static class Extensions
{
    public static void Reset(this Transform transform)
    {
        transform.ResetPosition();
        transform.ResetScale();
    }

    public static void ResetScale(this Transform transform)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public static void ResetPosition(this Transform transform)
    {
        transform.localPosition = Vector3.zero;
    }

    public static void SetX(this Transform transform, float posX)
    {
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }

    public static void SetY(this Transform transform, float posY)
    {
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }

    public static void SetZ(this Transform transform, float posZ)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, posZ);
    }
}
