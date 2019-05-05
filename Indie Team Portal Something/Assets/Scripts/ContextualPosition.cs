using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualPosition : MonoBehaviour
{
    public enum ContextualPositionType { Keyhole, Diorama }
    public ContextualPositionType myPositionType;
    private AssociatedPortalData myAssociatedPortals;
    [SerializeField]
    private GameObject MyHelpLight;
    public bool keyInPlace;
    public GameObject myAssignedObject;
    private BoxCollider myOwnCollider;
    [SerializeField]
    private PlacedDioramaPortalManager DioramaPortalManager;
    [SerializeField]
    private bool hasObjectToStart = false;
    [SerializeField]
    private GameObject startObject;
    [SerializeField]
    private AudioSource MyTargetAudioSource;


    //a script for locations that collect pickups to be placed.

        //if the object placed is a diorama, arrange it in its appropriate position and switch the portals to accomidate 
        //the new appropriate position.
        
        //deactivate your own collider and if the object you contain is picked up then deactivate and deactivate the portals associated.
    // Start is called before the first frame update
    void Start()
    {
        if (myPositionType == ContextualPositionType.Diorama)
        {
            myAssociatedPortals = GetComponent<AssociatedPortalData>();
        }

        myOwnCollider = GetComponent<BoxCollider>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (hasObjectToStart)
        {
            attachObjectOnStart();
        }
    }

    void attachObjectOnStart()
    {
        if (startObject == null)
        {
            Debug.Log("No startObject assigned. Assign Object to be linked in editor");
            return;
        }
        else {
            AttachToDioramaObject(startObject);
            PickupObjectScript targetScript = startObject.GetComponent<PickupObjectScript>();
            targetScript.GetAssignedPosition(this.gameObject);
            hasObjectToStart = false;
        }
    }

    public void AttachToDioramaObject(GameObject Target)
    {
        myAssignedObject = Target;
        PickupObjectScript targetScript = Target.GetComponent<PickupObjectScript>();
        targetScript.myownAssociatedPortals.myPosition = myAssociatedPortals.myPosition;
        DioramaPortalManager.CheckDioramaPlaced(myAssociatedPortals, targetScript.myownAssociatedPortals);
        myOwnCollider.enabled = false;
    }
    public void DetachToDioramaObject()
    {
        PickupObjectScript targetScript = myAssignedObject.GetComponent<PickupObjectScript>();
        DioramaPortalManager.CheckDioramaRemoved(myAssociatedPortals, targetScript.myownAssociatedPortals);
        targetScript.myownAssociatedPortals.myPosition = 0;
        myAssignedObject = null;
        myOwnCollider.enabled = true;
    }

    public void AttachToKeyObject(GameObject Target)
    {
        myAssignedObject = Target;
        PickupObjectScript targetScript = Target.GetComponent<PickupObjectScript>();
        targetScript.AttachToKeyPosition();
        myOwnCollider.enabled = false;
        keyInPlace = true;
        if (MyHelpLight != null)
        {
            MyHelpLight.SetActive(false);
        }
        
    }

    public AssociatedPortalData GetAttachedObjectPortalData()
    {
        return myAssignedObject.GetComponent<PickupObjectScript>().myownAssociatedPortals;
    }

    public void TriggerSound()
    {
        MyTargetAudioSource.Play();
    }
}
