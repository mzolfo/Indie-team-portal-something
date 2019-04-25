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

    //we want to rearrange all of these into lists... lists that just make this better to manage.
    //we need to make sure that every list lines up correctly so each trait is taken by each one individually and in order.

    [SerializeField]
    private List<int> portalCurrentDest;
    [SerializeField]
    private List<int> portalTargetDest;

    [SerializeField]
    private List<PortalCamera> portalCameras;
    [SerializeField]
    private List<MeshRenderer> renderPlanes;
   [SerializeField]
    private List<PortalTeleporter> colliderPlaneScripts;

    private int portalRevertDest;
    //end values to be changed

    //values to change to
    [SerializeField]
    private List<Material> cameraMaterials;


    [SerializeField]
    private List<GameObject> colliderPlanes;


    [SerializeField]
    private List<Transform> portalTransforms;
    

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
        //for (int i = 0; i < colliderPlanes.Count; i++)
       // {
       //     colliderPlaneScripts.Add(colliderPlanes[i].GetComponent<PortalTeleporter>());
       // }
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
        for (int i = 0; i < portalCurrentDest.Count; i++)
        {
            if (portalCurrentDest[i] != portalTargetDest[i])
            {
                BeginSwitch((i + 1), portalTargetDest[i]);
            }
        }
       
    }

    //if not then we begin the change

    public void BeginSwitch(int Primary, int Target)
    {
        // we have a portal and the destination it has been assigned to we need to switch the primary, target and targetlast
        deactivatorScript.ActivateTargetPortal(Primary);
        deactivatorScript.ActivateTargetPortal(Target);
        CheckTargetLastDestination(Target);
        if (portalRevertDest != 0)
        { RevertPortal(portalRevertDest); }
        CheckTargetLastDestination(Primary);
        if (portalRevertDest != 0)
        { RevertPortal(portalRevertDest); }
        //we know if something needs to be reverted now, now we need to start switching the portals.
        ChangePortalDestinationValues(Primary, Target);
        
        ChangePortalDestinationValues(Target, Primary);
        PortalRenderManager.UpdateCameraRenderTexture();
    }
    
    /// CHANGE WHEN ADDING
    //the following script tells if the destination of the target needs to be reverted.
    void CheckTargetLastDestination(int Target)
    {
        if (portalTargetDest[Target - 1] != 0)
        { portalRevertDest = portalCurrentDest[Target - 1]; } 
        else
        {
            deactivatorScript.ActivateTargetPortal(Target); // may need some + 1s
            return;
        }
    }

    

    public void RevertPortal(int RevertTarget) 
    {
        //set a portal's current and target dest to 0 and deactivate it.
        deactivatorScript.DeactivateTargetPortal(RevertTarget);
        portalRevertDest = 0;
        portalCameras[RevertTarget - 1].otherPortal = portalTransforms[13];
        portalTargetDest[RevertTarget - 1] = 0;
        portalCurrentDest[RevertTarget - 1] = 0;
    }

    void AssignPrimaryandTargetValues(int Primary, int Target)
    {

        primaryPortalCamera = portalCameras[Primary - 1];
        primaryPortalRenderPlane = renderPlanes[Primary - 1];
        primaryPortalColliderPlaneScript = colliderPlaneScripts[Primary - 1];
        //take the target portal and the primary portal and assign each value accordingly.

        targetPortalTransform = portalTransforms[Target - 1];
        targetPortalCameraMat = cameraMaterials[Target - 1];
        targetPortalColliderPlaneTransform = colliderPlanes[Target - 1].transform;
        
    }


        //this should change the portal's values to be assigned to its new destination but it must be told which portal and which destination
    void ChangePortalDestinationValues(int Primary, int Target) //this is just being called twice, once for each portal whose destination has changed.
    {
        AssignPrimaryandTargetValues(Primary, Target);
        primaryPortalCamera.otherPortal = targetPortalTransform;
        primaryPortalRenderPlane.material = targetPortalCameraMat;
        primaryPortalColliderPlaneScript.ChangeDestinationPortal(targetPortalColliderPlaneTransform);
        

        portalTargetDest[Primary - 1] = Target;
        portalCurrentDest[Primary - 1] = Target;
       

    }


}
