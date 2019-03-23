using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PickupObjectScript : MonoBehaviour
{
    public enum InteractType { Pickup, ContextualPickup, Diorama };
    
    public InteractType myInteractType;
    public string name;
    public int myAssociatedPortal;
    [SerializeField]
    private bool isPickedUp = false;
    [SerializeField]
    private bool isInContextualPosition = false;

    public Transform playerPickedUpPosition;
    public Transform playerDroppedPosition;
    [SerializeField]
    private Transform pickedUpPosition;
    [SerializeField]
    private BoxCollider myCollider;
    private Rigidbody myOwnRigidbody;
    private int startingLayer;

    // Start is called before the first frame update
    void Start()
    {
        myOwnRigidbody = GetComponent<Rigidbody>();
        myCollider = GetComponent<BoxCollider>();
        startingLayer = this.gameObject.layer;
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
        this.gameObject.layer = 12;
        this.gameObject.transform.position = pickedUpPosition.position;
        this.gameObject.transform.rotation = pickedUpPosition.rotation;

    }

    public void GetDropped()
    {
        this.gameObject.transform.position = new Vector3(playerDroppedPosition.position.x, playerPickedUpPosition.position.y, playerDroppedPosition.position.z);
        this.gameObject.transform.rotation = playerDroppedPosition.rotation;
        isPickedUp = false;
        myOwnRigidbody.isKinematic = false;
        myCollider.enabled = true;
        this.gameObject.layer = startingLayer;
    }

    public void GetAssignedPosition(GameObject PositionAssigned)
    {
        isInContextualPosition = true;
        isPickedUp = true;
        pickedUpPosition = PositionAssigned.transform;
        this.gameObject.transform.position = pickedUpPosition.position;
        this.gameObject.transform.rotation = pickedUpPosition.rotation;
        myCollider.enabled = true;
        this.gameObject.layer = startingLayer;
    }

}
