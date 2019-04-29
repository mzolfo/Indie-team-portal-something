using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSelfOnKeyPlaced : MonoBehaviour
{
    [SerializeField]
    private ContextualPosition TargetKeyhole;
    // Update is called once per frame
    void Update()
    {
        if (TargetKeyhole.keyInPlace)
        {
            DestroySelf();
        }
    }
    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
