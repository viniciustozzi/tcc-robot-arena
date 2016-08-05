using UnityEngine;
using System.Collections;

public class UsedBlocks : MonoBehaviour
{
	public void SetBlockHere(UIBlock block)
    {
        block.transform.parent = transform;
    }
}
