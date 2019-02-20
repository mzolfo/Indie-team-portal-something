using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDeactivator : MonoBehaviour
{

    [SerializeField]
    private GameObject renderPlane1;
    [SerializeField]
    private GameObject renderPlane2;
    [SerializeField]
    private GameObject renderPlane3;
    [SerializeField]
    private GameObject renderPlane4;

    [SerializeField]
    private GameObject colliderPlane1;
    [SerializeField]
    private GameObject colliderPlane2;
    [SerializeField]
    private GameObject colliderPlane3;
    [SerializeField]
    private GameObject colliderPlane4;

    private GameObject targetRenderPlane;
    private GameObject targetColliderPlane;

    private void Start()
    {
        DeactivateTargetPortal(1);
        DeactivateTargetPortal(2);
        DeactivateTargetPortal(3);
        DeactivateTargetPortal(4);
    }

    void IdentifyPortalFeatures(int Target)
    {
        if (Target == 1)
        {
            targetRenderPlane = renderPlane1;
            targetColliderPlane = colliderPlane1;
        }
        else if (Target == 2)
        {
            targetRenderPlane = renderPlane2;
            targetColliderPlane = colliderPlane2;
        }
        else if (Target == 3)
        {
            targetRenderPlane = renderPlane3;
            targetColliderPlane = colliderPlane3;
        }
        else if (Target == 4)
        {
            targetRenderPlane = renderPlane4;
            targetColliderPlane = colliderPlane4;
        }


    }

    public void ActivateTargetPortal(int Target)
    {
        IdentifyPortalFeatures(Target);
       // if (!targetRenderPlane.activeSelf)
       // {
            targetRenderPlane.SetActive(true);
            Debug.Log("Portal Number: " + Target + " has been activated.");
        //}

      //  if (!targetColliderPlane.activeSelf)
       // {
            targetColliderPlane.SetActive(true);
        //}
    }


    public void DeactivateTargetPortal(int Target)
    {
        IdentifyPortalFeatures(Target);
        //if (targetRenderPlane.activeSelf)
        //{
            targetRenderPlane.SetActive(false);
            Debug.Log("Portal Number: " + Target + " has been deactivated.");
        //}

       // if (targetColliderPlane.activeSelf)
        //{
            targetColliderPlane.SetActive(false);
        //}
    }
}
