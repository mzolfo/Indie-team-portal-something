using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPushScript : MonoBehaviour
{
    [SerializeField]
    float pushForce = 5f;

    private Vector3 force;
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Bonk");
        if(hit.rigidbody != null && !hit.rigidbody.isKinematic)
        {
            Debug.Log("push");
            force = Vector3.Normalize(cc.velocity + transform.forward) * pushForce;
            hit.rigidbody.AddForce(force);
        }
    }
}
