using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxThrow : MonoBehaviour
{

    private Rigidbody myRigidBody;
    
    [SerializeField]
    private Vector3 forceToAdd;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowSelf()
    {
        myRigidBody.isKinematic = false;
        myRigidBody.AddForce(forceToAdd);
    }

}
