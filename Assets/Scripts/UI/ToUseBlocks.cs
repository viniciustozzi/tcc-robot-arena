using UnityEngine;
using System.Collections;

public class ToUseBlocks : MonoBehaviour
{
    public void SetBlockHere(UIBlock block)
    {
        block.transform.parent = transform;
    }
}
