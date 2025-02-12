using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Branch : MonoBehaviour
{
    public static float bottomY = -18f;
    private bool hasTriggeredMiss = false;

    void Update()
    {
        if (!hasTriggeredMiss && transform.position.y < bottomY)
        {
            hasTriggeredMiss = true;
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleMissed();
            Destroy(this.gameObject);
        }
    }
}
