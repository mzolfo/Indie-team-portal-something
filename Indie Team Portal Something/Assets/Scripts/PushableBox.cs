using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBox : MonoBehaviour
{
    [SerializeField]
    float respawnThreshold = -20f;

    private Rigidbody rb;
    private Vector3 startingPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPoint = transform.position;
    }

    private void Update()
    {
        if (transform.position.y < respawnThreshold)
            transform.position = startingPoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeliveryPoint")
            rb.isKinematic = true;
    }
}
