using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractScript : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerCamera;
    [SerializeField]
    private GameObject pickedUpObject;
    private PickupObjectScript pickedUpObjectScript;
    [SerializeField]
    private Text InteractText;
    


    [SerializeField]
    private Transform playerPickedUpPosition;
    [SerializeField]
    private Transform playerDroppedPosition;

    private Transform logTransformMess;

    [SerializeField]
    private GameObject reachableInteractableObject;

    private bool interactableInRange;

    //player casts a ray from where they can see, if the ray intersects an object that can be interacted with then 
    //interactableinrange = true and check what sort of interaction can be had with it.
    //if the object is a pickup then when the player presses e they move the object on update to the position attached to the player
    //near their point of view

    //if the object is simply interactable then start their interaction
    //if the player is holding an object then when pressing q the object regains its physics and drops from whereever the player
    //was holding it
   
    // Update is called once per frame
    void Update()
    {
       
        CheckIfInteractableIsInRange();
        if (Input.GetButtonDown("Interact"))
        {
            if (interactableInRange)
            { AttemptToInteract(); }
            
        }

        if (Input.GetButtonDown("Drop"))
        {
            if (pickedUpObject != null)
            {
                DropPickedUpObject(pickedUpObject.GetComponent<PickupObjectScript>());
            }
        }
    }

    void CheckIfInteractableIsInRange()
    {
       

        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, 4))
        {
            Debug.DrawLine(PlayerCamera.transform.position, hit.point, Color.red, 1);
            if (hit.transform.gameObject.tag == "Interactable")
            {
                reachableInteractableObject = hit.transform.gameObject;
                if (reachableInteractableObject.GetComponent<ContextualPosition>() != null)
                {
                    if (pickedUpObject != null)
                    {
                        interactableInRange = true;
                        InteractText.text = "E: Place " + pickedUpObjectScript.name;
                    }
                    else { reachableInteractableObject = null; }
                }
                else if (reachableInteractableObject.GetComponent<PickupObjectScript>() != null)
                {
                    interactableInRange = true;
                    InteractText.text = "E: Pickup " + reachableInteractableObject.GetComponent<PickupObjectScript>().name;
                }
                else
                {
                    interactableInRange = true;
                }
                
            }
            else
            {
                reachableInteractableObject = null;
                interactableInRange = false;
                InteractText.text = "";
            }
        }
        else
        {
            reachableInteractableObject = null;
            interactableInRange = false;
            InteractText.text = "";
        }
    }

    void AttemptToInteract()
    {

        if (reachableInteractableObject.GetComponent<PickupObjectScript>() != null)
        {
            if (pickedUpObject == null)
            {
                pickedUpObjectScript = reachableInteractableObject.GetComponent<PickupObjectScript>();
                PickUpObject(pickedUpObjectScript);

            }
        }
        else if (reachableInteractableObject.GetComponent<ContextualPosition>() != null)
        {
            pickedUpObjectScript = pickedUpObject.GetComponent<PickupObjectScript>();
            ContextualPosition targetScript = reachableInteractableObject.GetComponent<ContextualPosition>();
            if (pickedUpObjectScript.myInteractType == PickupObjectScript.InteractType.Diorama)
            {
                pickedUpObjectScript.GetAssignedPosition(reachableInteractableObject);
                targetScript.AttachToDioramaObject(pickedUpObject);
                pickedUpObject = null;
                reachableInteractableObject = null;
                interactableInRange = false;
            }
            else if (pickedUpObjectScript.myInteractType == PickupObjectScript.InteractType.ContextualPickup)
            {
                //define the placement of pickups in non diorama positions.
            }

        }
        else if (reachableInteractableObject.GetComponent<BasicOnOffSwitch>() != null)
        {
            reachableInteractableObject.GetComponent<BasicOnOffSwitch>().ToggleActiveStateOfTarget();
        }
        //this only reacts if the interactable is a pickup
    }


    void PickUpObject(PickupObjectScript target)
    {
        //if the object is a pickup and there is no pickup in hand then pick it up.
        pickedUpObject = reachableInteractableObject;
        target.playerPickedUpPosition = playerPickedUpPosition;
        target.playerDroppedPosition = playerDroppedPosition;
        target.GetPickedUp();
        reachableInteractableObject = null;
    }

    void DropPickedUpObject(PickupObjectScript target)
    {
        //logTransformMess = this.transform;
        target.GetDropped();
        pickedUpObject = null;

        //this.transform.position = logTransformMess.position;
        //this.transform.rotation = logTransformMess.rotation;
    }
    

}
