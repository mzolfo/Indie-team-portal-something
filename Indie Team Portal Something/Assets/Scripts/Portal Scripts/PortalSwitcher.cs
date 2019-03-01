using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSwitcher : MonoBehaviour
{
    /// <summary>
    /// this script is made to handle the changing destinations of different portals during runtime
    /// it needs to change each portal's diplayed view as well as the destination it travels to.
    /// </summary>
    /// 
    [SerializeField]
    private PortalTextureSetup PortalRenderManager;
    [SerializeField]
    private PortalDeactivator deactivatorScript;

    //public static bool Foldout(bool foldout, string content, bool toggleOnLabelClick, GUIStyle style = EditorStyles.foldout); 
    //values to be changed

    [SerializeField]
    private int portalCurrentDest1 = 0;
    [SerializeField]
    private int portalCurrentDest2 = 0;
    [SerializeField]
    private int portalCurrentDest3 = 0;
    [SerializeField]
    private int portalCurrentDest4 = 0;

    [SerializeField]
    private int portalTargetDest1 = 0;
    [SerializeField]
    private int portalTargetDest2 = 0;
    [SerializeField]
    private int portalTargetDest3 = 0;
    [SerializeField]
    private int portalTargetDest4 = 0;
    [Header("portalCameras")]
    [SerializeField]
    private PortalCamera camera1;
    [SerializeField]
    private PortalCamera camera2;
    [SerializeField]
    private PortalCamera camera3;
    [SerializeField]
    private PortalCamera camera4;

    [Header("Render Planes")]
    [SerializeField]
    private MeshRenderer renderPlane1;
    [SerializeField]
    private MeshRenderer renderPlane2;
    [SerializeField]
    private MeshRenderer renderPlane3;
    [SerializeField]
    private MeshRenderer renderPlane4;

    
    private PortalTeleporter colliderPlaneScript1;    
    private PortalTeleporter colliderPlaneScript2;    
    private PortalTeleporter colliderPlaneScript3;    
    private PortalTeleporter colliderPlaneScript4;

    

    private int portalRevertDest;
    //end values to be changed

    //values to change to
    [Header("Camera Materials")]
    [SerializeField]
    private Material CameraMat_1;
    [SerializeField]
    private Material CameraMat_2;
    [SerializeField]
    private Material CameraMat_3;
    [SerializeField]
    private Material CameraMat_4;

    [Header("Collider Planes")]
    [SerializeField]
    private GameObject colliderPlane1;
    [SerializeField]
    private GameObject colliderPlane2;
    [SerializeField]
    private GameObject colliderPlane3;
    [SerializeField]
    private GameObject colliderPlane4;

    [Header("Portal Transforms")]
    [SerializeField]
    private Transform framePortal1;
    [SerializeField]
    private Transform framePortal2;
    [SerializeField]
    private Transform framePortal3;
    [SerializeField]
    private Transform framePortal4;

    //end values to change to
    
    private PortalCamera primaryPortalCamera;
    private Transform targetPortalTransform;
    private MeshRenderer primaryPortalRenderPlane;
    private Material targetPortalCameraMat;
    private PortalTeleporter primaryPortalColliderPlaneScript;
    private Transform targetPortalColliderPlaneTransform;

    
    // Start is called before the first frame update
    void Start()
    {
        colliderPlaneScript1 = colliderPlane1.GetComponent<PortalTeleporter>();
        colliderPlaneScript2 = colliderPlane2.GetComponent<PortalTeleporter>();
        colliderPlaneScript3 = colliderPlane3.GetComponent<PortalTeleporter>();
        colliderPlaneScript4 = colliderPlane4.GetComponent<PortalTeleporter>();
        deactivatorScript = GetComponent<PortalDeactivator>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckDestinationsAreEqual();

        //if (portalRevertDest != 0)
       // { RevertPortal(portalRevertDest); }
    }



    void CheckDestinationsAreEqual()
    {
        if (portalCurrentDest1 != portalTargetDest1)
        { BeginSwitch(1, portalTargetDest1); }
        if (portalCurrentDest2 != portalTargetDest2)
        { BeginSwitch(2, portalTargetDest2); }
        if (portalCurrentDest3 != portalTargetDest3)
        { BeginSwitch(3, portalTargetDest3); }
        if (portalCurrentDest4 != portalTargetDest4)
        { BeginSwitch(4, portalTargetDest4); }
    }

    //if not then we begin the change

    public void BeginSwitch(int Primary, int Target)
    {
        // we have a portal and the destination it has been assigned to we need to switch the primary, target and targetlast
        deactivatorScript.ActivateTargetPortal(Primary);
        CheckTargetLastDestination(Target);
        if (portalRevertDest != 0)
        { RevertPortal(portalRevertDest); }
        CheckTargetLastDestination(Primary);
        if (portalRevertDest != 0)
        { RevertPortal(portalRevertDest); }
        //we know if something needs to be reverted now, now we need to start switching the portals.
        ChangePortalDestinationValues(Primary, Target);
        

      //  CheckTargetLastDestination(Primary);
        ChangePortalDestinationValues(Target, Primary);
       // if (portalRevertDest != 0)
       // { RevertPortal(portalRevertDest); }
        PortalRenderManager.UpdateCameraRenderTexture();
    }
    
    /// CHANGE WHEN ADDING
    //the following script tells if the destination of the target needs to be reverted.
    void CheckTargetLastDestination(int Target)
    {
        if (Target == 1)
        {
            if (portalTargetDest1 == 0) {
                deactivatorScript.ActivateTargetPortal(Target);
                return;
            }
            else { portalRevertDest = portalCurrentDest1; }
        }
        else if (Target == 2)
        {
            if (portalTargetDest2 == 0) { deactivatorScript.ActivateTargetPortal(Target); return; }
            else { portalRevertDest = portalCurrentDest2; }
        }
        else if (Target == 3)
        {
            if (portalTargetDest3 == 0) { deactivatorScript.ActivateTargetPortal(Target); return; }
            else { portalRevertDest = portalCurrentDest3; }
        }
        else if (Target == 4)
        {
            if (portalTargetDest4 == 0) { deactivatorScript.ActivateTargetPortal(Target); return; }
            else { portalRevertDest = portalCurrentDest4; }
        }
    }

    

    public void RevertPortal(int RevertTarget) 
    {
        //set a portal's current and target dest to 0 and deactivate it.
        deactivatorScript.DeactivateTargetPortal(RevertTarget);
        portalRevertDest = 0;
        if (RevertTarget == 1)
        {
            portalTargetDest1 = 0;
            portalCurrentDest1 = 0;
        }
        else if (RevertTarget == 2)
        {
            portalTargetDest2 = 0;
            portalCurrentDest2 = 0;
        }
        else if (RevertTarget == 3)
        {
            portalTargetDest3 = 0;
            portalCurrentDest3 = 0;
        }
        else if (RevertTarget == 4)
        {
            portalTargetDest4 = 0;
            portalCurrentDest4 = 0;
        }
    }

    void AssignPrimaryandTargetValues(int Primary, int Target)
    {
        //take the target portal and the primary portal and assign each value accordingly.
        if (Primary == 1)
        {
            primaryPortalCamera = camera1;
            primaryPortalRenderPlane = renderPlane1;
            primaryPortalColliderPlaneScript = colliderPlaneScript1;
        }
        else if (Primary == 2)
        {
            primaryPortalCamera = camera2;
            primaryPortalRenderPlane = renderPlane2;
            primaryPortalColliderPlaneScript = colliderPlaneScript2;
        }
        else if (Primary == 3)
        {
            primaryPortalCamera = camera3;
            primaryPortalRenderPlane = renderPlane3;
            primaryPortalColliderPlaneScript = colliderPlaneScript3;
        }
        else if (Primary == 4)
        {
            primaryPortalCamera = camera4;
            primaryPortalRenderPlane = renderPlane4;
            primaryPortalColliderPlaneScript = colliderPlaneScript4;
        }

        if (Target == 1)
        {
            targetPortalTransform = framePortal1;
            targetPortalCameraMat = CameraMat_1;
            targetPortalColliderPlaneTransform = colliderPlane1.transform;
        }
        else if (Target == 2)
        {
            targetPortalTransform = framePortal2;
            targetPortalCameraMat = CameraMat_2;
            targetPortalColliderPlaneTransform = colliderPlane2.transform;
        }
        else if (Target == 3)
        {
            targetPortalTransform = framePortal3;
            targetPortalCameraMat = CameraMat_3;
            targetPortalColliderPlaneTransform = colliderPlane3.transform;
        }
        else if (Target == 4)
        {
            targetPortalTransform = framePortal4;
            targetPortalCameraMat = CameraMat_4;
            targetPortalColliderPlaneTransform = colliderPlane4.transform;
        }
    }


        //this should change the portal's values to be assigned to its new destination but it must be told which portal and which destination
    void ChangePortalDestinationValues(int Primary, int Target) //this is just being called twice, once for each portal whose destination has changed.
    {
        AssignPrimaryandTargetValues(Primary, Target);
        primaryPortalCamera.otherPortal = targetPortalTransform;
        primaryPortalRenderPlane.material = targetPortalCameraMat;
        primaryPortalColliderPlaneScript.reciever = targetPortalColliderPlaneTransform;

        if (Primary == 1)
        {
            portalTargetDest1 = Target;
            portalCurrentDest1 = Target;
        }
        else if (Primary == 2)
        {
            portalTargetDest2 = Target;
            portalCurrentDest2 = Target;
        }
        else if (Primary == 3)
        {
            portalTargetDest3 = Target;
            portalCurrentDest3 = Target;
        }
        else if (Primary == 4)
        {
            portalTargetDest4 = Target;
            portalCurrentDest4 = Target;
        }

    }


}
