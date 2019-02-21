using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PickupObjectScript : MonoBehaviour
{

    
    public int myAssociatedPortal;
    [SerializeField]
    private bool isPickedUp = false;
    [SerializeField]
    private bool isInContextualPosition = false;
    [SerializeField]
    private Transform playerPickedUpPosition;
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
        if (isInContextualPosition)
        {
           ContextualPosition positionScript = pickedUpPosition.gameObject.GetComponent<ContextualPosition>();
            positionScript.DetachToDioramaObject();

        }
        pickedUpPosition = playerPickedUpPosition;
        isInContextualPosition = false;
        isPickedUp = true;
        myCollider.enabled = false;
        myOwnRigidbody.isKinematic = true;
        this.gameObject.transform.position = pickedUpPosition.position;
        this.gameObject.transform.rotation = pickedUpPosition.rotation;

    }

    public void GetDropped()
    {
        isPickedUp = false;
        myCollider.enabled = true;
        myOwnRigidbody.isKinematic = false;
    }

    public void GetAssignedPosition(GameObject PositionAssigned)
    {
        isInContextualPosition = true;
        isPickedUp = true;
        this.gameObject.transform.position = pickedUpPosition.position;
        this.gameObject.transform.rotation = pickedUpPosition.rotation;
        myCollider.enabled = true;
        pickedUpPosition = PositionAssigned.transform;
    }

}
