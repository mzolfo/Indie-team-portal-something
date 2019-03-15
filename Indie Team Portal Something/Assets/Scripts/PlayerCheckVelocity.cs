using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckVelocity : MonoBehaviour
{
    [SerializeField]
    private Rigidbody myRigidbody;

    [SerializeField]
    private float exposeX;
    [SerializeField]
    private float exposeY;
    [SerializeField]
    private float exposeZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        exposeX = myRigidbody.velocity.x;
        exposeY = myRigidbody.velocity.y;
        exposeZ = myRigidbody.velocity.z;
    }
}
