using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjectScript : MonoBehaviour
{
    [SerializeField]
    private bool isPickedUp = false;

    [SerializeField]
    private Transform pickedUpPosition;
    [SerializeField]
    private BoxCollider myCollider;
    private Rigidbody myOwnRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myOwnRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            this.gameObject.transform.position = pickedUpPosition.position;
            this.gameObject.transform.rotation = pickedUpPosition.rotation;
        }
    }

    public void GetPickedUp()
    {
        isPickedUp = true;
        myCollider.enabled = !myCollider.enabled;
        myOwnRigidbody.isKinematic = true;
    }

    public void GetDropped()
    {
        isPickedUp = false;
        myCollider.enabled = true;
        myOwnRigidbody.isKinematic = false;
    }

    public void GetAssignedPosition(GameObject PositionAssigned)
    {

    }

}
