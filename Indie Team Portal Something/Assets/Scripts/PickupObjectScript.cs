using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PickupObjectScript : MonoBehaviour
{
    public enum InteractType { Pickup, Key, Diorama };
    
    public InteractType myInteractType;
    public string title;
    public AssociatedPortalData myownAssociatedPortals;
    [SerializeField]
    private bool isPickedUp = false;
    [SerializeField]
    private bool isInContextualPosition = false;

    [SerializeField]
    private ContextualPosition myKeyholePosition;
    
    public Transform playerPickedUpPosition;
    public Transform playerDroppedPosition;
    [SerializeField]
    private Transform lockToPosition;
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
        if (myInteractType == InteractType.Diorama)
        {
            myownAssociatedPortals = GetComponent<AssociatedPortalData>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            this.gameObject.transform.position = lockToPosition.position;
            this.gameObject.transform.rotation = lockToPosition.rotation;
        }
    }

    public void GetPickedUp()
    {
        if (isInContextualPosition)
        {
           ContextualPosition positionScript = lockToPosition.gameObject.GetComponent<ContextualPosition>();
            positionScript.DetachToDioramaObject();
        }
        lockToPosition = playerPickedUpPosition;
        isInContextualPosition = false;
        isPickedUp = true;
        myCollider.enabled = false;
        myOwnRigidbody.isKinematic = true;
        this.gameObject.layer = 12;
        this.gameObject.transform.position = lockToPosition.position;
        this.gameObject.transform.rotation = lockToPosition.rotation;

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
        lockToPosition = PositionAssigned.transform;
        this.gameObject.transform.position = lockToPosition.position;
        this.gameObject.transform.rotation = lockToPosition.rotation;
        myCollider.enabled = true;
        this.gameObject.layer = startingLayer;
    }

    public void AttachToKeyPosition()
    {
        lockToPosition.position = new Vector3(lockToPosition.position.x, lockToPosition.position.y, lockToPosition.position.z);
        myCollider.enabled = false;
    }
   

}
