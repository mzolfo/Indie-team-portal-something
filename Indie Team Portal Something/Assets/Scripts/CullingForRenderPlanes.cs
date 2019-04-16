using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingForRenderPlanes : MonoBehaviour
{
    public bool portalIsActive; //check if this is supposed to be on
    private BoxCollider myOwnCollider;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private bool isFacedByPlayerCamera;
    private GameObject player;
    [SerializeField]
    private bool isGrandhallPortal;
    private CurrentRoomCheck PlayerInGrandHallTracker;
    private MeshRenderer myMeshRenderer;
    public bool renderPlaneIsActive;
    // Start is called before the first frame update
    void Start()
    {
        myOwnCollider = GetComponent<BoxCollider>();
        player = GameObject.Find("RigidbodyPlayer");
        PlayerInGrandHallTracker = player.GetComponent<CurrentRoomCheck>();
        myMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        CheckIsFacedByPlayerCamera();
        if (isFacedByPlayerCamera && portalIsActive)
        {
            if (isGrandhallPortal && PlayerInGrandHallTracker.isInGrandHall)
            {
                TurnOnIfInactive();
            }
            else if (isGrandhallPortal && !PlayerInGrandHallTracker.isInGrandHall)
            {
                TurnOffIfActive();
            }
            else if (!isGrandhallPortal && PlayerInGrandHallTracker.isInGrandHall)
            {
                TurnOffIfActive();
            }
            else if (!isGrandhallPortal && !PlayerInGrandHallTracker.isInGrandHall)
            {
                TurnOnIfInactive();
            }

        }
        else
        {
            TurnOffIfActive();
        }
    }


    void TurnOffIfActive()
    {
        if (myMeshRenderer.enabled)
        {
            SetSelfInactive();
        }
        else { return; }
    }

    void TurnOnIfInactive()
    {
        if (myMeshRenderer.enabled)
        {
            return;
        }
        else
        {
            SetSelfActive();
        }
    }

    void CheckIsFacedByPlayerCamera()
    {
        if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(playerCamera), myOwnCollider.bounds))
        { isFacedByPlayerCamera = true; }
        else { isFacedByPlayerCamera = false; }
    }

    private void SetSelfInactive()
    {
        myMeshRenderer.enabled = false;
        renderPlaneIsActive = false;
    }

    private void SetSelfActive()
    {
        myMeshRenderer.enabled = true;
        renderPlaneIsActive = true;
    }
    /*
    public void CheckIfVisibleByPlayerCamera()
    { //the long line below should return whether the bounds of the object is in view of the playerCamera.
        if (GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(playerCamera), myOwnCollider.bounds))
        {
            isVisibleByPlayerCamera = true;
        }
        else
        { isVisibleByPlayerCamera = false; }
    }
    */
}
