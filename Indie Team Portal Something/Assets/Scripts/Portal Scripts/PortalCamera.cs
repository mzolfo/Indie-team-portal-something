using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    
   // [SerializeField]
   // private Vector3 exposePlayerOffset;
   

    Quaternion portalRotationalDifference;
    [SerializeField]
    private bool isCameraA = false; //determines whether this camera is an entrance or an exit if it matters
    [SerializeField]
    private float RotationOfPortalA; //either 90,-90, 0 or 180
    [SerializeField]
    private Quaternion exposeRotationalDifference;
    [SerializeField]
    private Vector3 newCameraDirection;

    //run the same offset script with an edit depending on the connected portal's rotation.
    //if one's own portal is of a y rotation of 0 then check the other portal's y rotation and defer to its instruction


    // Update is called once per frame
    void LateUpdate()
    {
        CheckOffsetShiftByPortalRotations();
        OffsetTransformDependentOnPortalARotation();
    }

    void CheckOffsetShiftByPortalRotations()
    {
        //if your own rotation is not 0 you are camera A, if it is you may be camera b, if both are 0 it doesnt matter.
        if (portal.rotation.eulerAngles.y == 0)
        {
            if (otherPortal.rotation.eulerAngles.y == 0)
            {
                RotationOfPortalA = 0;
            }
            else
            {
                RotationOfPortalA = otherPortal.rotation.eulerAngles.y;
                isCameraA = false;
            }
        }
        else
        {
            RotationOfPortalA = portal.rotation.eulerAngles.y;
            isCameraA = true;
        }
    }

    void OffsetTransformDependentOnPortalARotation()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;

        if (RotationOfPortalA == 0)
        {
            transform.position = new Vector3(portal.position.x - playerOffsetFromPortal.x, portal.position.y + playerOffsetFromPortal.y, portal.position.z - playerOffsetFromPortal.z);
            // portal.position + playerOffsetFromPortal;
            portalRotationalDifference = Quaternion.AngleAxis(180, Vector3.up);
            newCameraDirection = portalRotationalDifference * playerCamera.forward;
        }
        else if (RotationOfPortalA == 180)
        {
            transform.position = new Vector3(portal.position.x + playerOffsetFromPortal.x, portal.position.y + playerOffsetFromPortal.y, portal.position.z + playerOffsetFromPortal.z);
            portalRotationalDifference = Quaternion.AngleAxis(0, Vector3.up);
            newCameraDirection = portalRotationalDifference * playerCamera.forward;
        }
        else if (RotationOfPortalA == 90)
        {
            transform.position = new Vector3(portal.position.x + playerOffsetFromPortal.z, portal.position.y + playerOffsetFromPortal.y, portal.position.z + playerOffsetFromPortal.x);
            if (isCameraA)
            {
                portalRotationalDifference = Quaternion.AngleAxis(-90, Vector3.up);
            }
            else {  portalRotationalDifference = Quaternion.AngleAxis(90, Vector3.up); }
            newCameraDirection = portalRotationalDifference * playerCamera.forward;
        }
        else if (RotationOfPortalA == 270)
        {
            transform.position = new Vector3(portal.position.x - playerOffsetFromPortal.z, portal.position.y + playerOffsetFromPortal.y, portal.position.z - playerOffsetFromPortal.x);
            if (isCameraA)
            {
                 portalRotationalDifference = Quaternion.AngleAxis(90, Vector3.up);
            }
            else {  portalRotationalDifference = Quaternion.AngleAxis(-90, Vector3.up); }
            newCameraDirection = portalRotationalDifference * playerCamera.forward; //can i reverse newcameradirection's x component and also revolve it by 180 per update? will that solve the issue?

        }
        

        //try setting the value it multiplies here to playercamera forward with negative x value

        newCameraDirection = new Vector3(newCameraDirection.x, newCameraDirection.y, newCameraDirection.z);

        

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);

        //new position must interact with the offset differently depending on the rotation of each portal. 
        //for 0 x - x, y + y, z - z
        //for 180 x+x, y+y, z+z
        //for 90 x+z, y+y, z+z
        //for -90 x-z, y+y, z-x
        //float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);


        //where angular diff was needs to be set to 0, 180, 90 or -90 depending on the rotation of the portals
    }
}
