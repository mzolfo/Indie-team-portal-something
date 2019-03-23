using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : MonoBehaviour
{

    [SerializeField]
    private GameObject parent;
    private int parentLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        parentLayer = parent.layer;
        this.gameObject.layer = parentLayer;
            
    }
}
