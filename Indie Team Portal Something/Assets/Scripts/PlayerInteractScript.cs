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
    

    private bool keyInPosition;
    [SerializeField]
    private Transform playerPickedUpPosition;
    [SerializeField]
    private Transform playerDroppedPosition;

    

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
            Debug.DrawLine(PlayerCamera.transform.position, hit.point, Color.red, 1); //cast a ray to see if we hit something
            if (hit.transform.gameObject.tag == "Interactable") //if we did and it is an interactable
            {
                reachableInteractableObject = hit.transform.gameObject; //collect it to be analyzed
                if (CheckIfInteractableIsContextualPosition()) //if it was a contextual position this will deal with it if not
                    //it will return false and pass to the next else if
                {
                    return;
                }
                else if (CheckIfInteractabeIsPickupObject())//if it was a pickup Object this will deal with it if not
                                                            //it will return false and pass to the next else if
                {
                    return;
                }
                else
                {
                    interactableInRange = true;
                }
                
            }
            else
            {
                InstructInteractableCannotBeInteractedWith();
            }
        }
        else
        {
            InstructInteractableCannotBeInteractedWith();
        }
    }

    private bool CheckIfInteractableIsContextualPosition()
    {
        if (reachableInteractableObject.GetComponent<ContextualPosition>() != null) //check if it is a contextualposition
        { //if so check if you are holding something
            if (pickedUpObject != null)
            { //we dont want what follows as is. 
                if (CheckIfObjectCanBePlaced())
                {
                    InstructCanPlaceObject();
                }
                else { InstructCannotPlaceObject(); }
            }
            else { reachableInteractableObject = null; } //if not you cant interact with it
            return true;
        }
        else { return false; }

    }

    private bool CheckIfObjectCanBePlaced()
    {
        ContextualPosition TargetScript = reachableInteractableObject.GetComponent<ContextualPosition>();
        if (TargetScript.myPositionType == ContextualPosition.ContextualPositionType.Keyhole)
        {
            if (TargetScript.myAssignedObject == pickedUpObject)
            {
                return true;
            }
            else { return false; }
        }
        else if (TargetScript.myPositionType == ContextualPosition.ContextualPositionType.Diorama)
        {
            if (pickedUpObjectScript.myInteractType == PickupObjectScript.InteractType.Diorama)
            {
                return true;
            }
            else { return false; }
        }
        else { return false; }
        
    }

    private bool CheckIfInteractabeIsPickupObject()
    {
        if (reachableInteractableObject.GetComponent<PickupObjectScript>() != null)
        {
            if (pickedUpObject != null)
            {
                InstructHandsAreFull();
            }
            else
            {
                interactableInRange = true;
                InteractText.text = "E: Pickup " + reachableInteractableObject.GetComponent<PickupObjectScript>().title;
            }
            return true;
        }
        else { return false; }
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
            if (pickedUpObject != null)
            {
                if (CheckIfObjectCanBePlaced())
                {
                    pickedUpObjectScript.GetAssignedPosition(reachableInteractableObject);
                    if (pickedUpObjectScript.myInteractType == PickupObjectScript.InteractType.Diorama)
                    {
                        reachableInteractableObject.GetComponent<ContextualPosition>().AttachToDioramaObject(pickedUpObject);
                    }
                    else if (pickedUpObjectScript.myInteractType == PickupObjectScript.InteractType.Key)
                    {
                        reachableInteractableObject.GetComponent<ContextualPosition>().AttachToKeyObject(pickedUpObject);
                    }
                    pickedUpObject = null;
                    reachableInteractableObject = null;
                    interactableInRange = false;
                }
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
        target.GetDropped();
        pickedUpObject = null; 
    }

    void InstructInteractableCannotBeInteractedWith()
    {
        reachableInteractableObject = null;
        interactableInRange = false;
        InteractText.text = "";
    }

    void InstructCannotPlaceObject()
    {
        interactableInRange = false;
        InteractText.text = "That doesn't go there.";
    }

    void InstructCanPlaceObject()
    {
        interactableInRange = true;
        InteractText.text = "E: Place " + pickedUpObjectScript.title;
    }

    void InstructHandsAreFull()
    {
        interactableInRange = false;
        InteractText.text = "you are already holding the " + pickedUpObjectScript.title;
    }

}
