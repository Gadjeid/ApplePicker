using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Branch : MonoBehaviour
{
    public static float bottomY = -18f;

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
