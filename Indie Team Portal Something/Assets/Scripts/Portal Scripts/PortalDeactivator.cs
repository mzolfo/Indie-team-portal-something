using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDeactivator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> renderPlanes;
    [SerializeField]
    private List<GameObject> colliderPlanes;
    

    private GameObject targetRenderPlane;
    private GameObject targetColliderPlane;

    private void Start()
    {
        //DeactivateTargetPortal(1);
        //DeactivateTargetPortal(2);
        for (int i = 3; i <= renderPlanes.Count; i++)
        { DeactivateTargetPortal(i); }
        
    }

    void IdentifyPortalFeatures(int Target)
    {
        targetRenderPlane = renderPlanes[Target - 1];
        targetColliderPlane = colliderPlanes[Target - 1];
    }

    public void ActivateTargetPortal(int Target)
    {
        IdentifyPortalFeatures(Target);

        //targetRenderPlane.SetActive(true);
        targetRenderPlane.GetComponent<CullingForRenderPlanes>().portalIsActive = true;
        Debug.Log("Portal Number: " + Target + " has been activated.");
        
            targetColliderPlane.SetActive(true);
        
    }


    public void DeactivateTargetPortal(int Target)
    {
        IdentifyPortalFeatures(Target);

        //targetRenderPlane.SetActive(false);
        targetRenderPlane.GetComponent<CullingForRenderPlanes>().portalIsActive = false;

            Debug.Log("Portal Number: " + Target + " has been deactivated.");
            targetColliderPlane.SetActive(false);
       
    }
}
