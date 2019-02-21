using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwaySizeFinder : MonoBehaviour
{
    [SerializeField]
    private Vector3 raycastUpHit;
    [SerializeField]
    private Vector3 raycastDownHit;
    [SerializeField]
    private Vector3 raycastLeftHit;
    [SerializeField]
    private Vector3 raycastRightHit;

    private float upDownDistance;
    private float rightLeftDistance;

    [SerializeField]
    private float ydist;
    [SerializeField]
    private float zdist;
    //[SerializeField]
    //private float xdist;

    private Transform myOwnLocation;
    //eventually we want to resize the environment so that the doorway is exactly the same size and its origin is at the same
    //point.

    //raycast to 4 vectors, up, left, right, and down, find the points they intersect
    //average the distance between left and right point and up and down point and place yourself there to be at the center
    //also return the difference between the larger and smaller value to give me the exact size.
    //left and right are along the z axis in worldspace.
    // Start is called before the first frame update
    void Start()
    {
        myOwnLocation = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FindDistanceLeftAndRight();
        FindDistanceUpAndDown();
    }

    void FindDistanceLeftAndRight()
    {
        RaycastHit hit;
        if (Physics.Raycast(myOwnLocation.position, new Vector3(0, 0, 1), out hit)) //if it hits anything
        {
            Debug.DrawLine(myOwnLocation.transform.position, hit.point, Color.red, 1);
            raycastLeftHit = hit.point;
        }

        if (Physics.Raycast(myOwnLocation.position, new Vector3(0, 0, -1), out hit)) //if it hits anything
        {
            Debug.DrawLine(myOwnLocation.transform.position, hit.point, Color.red, 1);
            raycastRightHit = hit.point;
        }

        if (raycastLeftHit != null && raycastRightHit != null)
        {
            FindAverageDistanceAndCenterPoint(raycastLeftHit, raycastRightHit);
        }
    }

    void FindDistanceUpAndDown()
    {
        RaycastHit hit;
        if (Physics.Raycast(myOwnLocation.position, Vector3.up, out hit)) //if it hits anything
        {
            Debug.DrawLine(myOwnLocation.transform.position, hit.point, Color.red, 1);
            raycastUpHit = hit.point;
        }
        
        if (Physics.Raycast(myOwnLocation.position, Vector3.down, out hit)) //if it hits anything
        {
            Debug.DrawLine(myOwnLocation.transform.position, hit.point, Color.red, 1);
            raycastDownHit = hit.point;
        }

        if (raycastDownHit != null && raycastUpHit != null)
        {
            FindAverageDistanceAndCenterPoint(raycastUpHit, raycastDownHit);
        }

    }

    void FindAverageDistanceAndCenterPoint(Vector3 firstEnd, Vector3 SecondEnd)
    {
        float yave;
        float zave;
        float xave;
        ydist = Mathf.Abs(raycastUpHit.y - raycastDownHit.y);
        zdist = Mathf.Abs(raycastLeftHit.z - raycastRightHit.z);
        //xdist = Mathf.Abs(SecondEnd.x - firstEnd.x);
        //avg formula larger + smaller /2 = avg
        //dist formula larger - smaller = dist
        
        if (firstEnd.y != SecondEnd.y)
        {
            yave = (firstEnd.y + SecondEnd.y) / 2;
            myOwnLocation.position = new Vector3(myOwnLocation.position.x, yave, myOwnLocation.position.z);
           
        }
        if (firstEnd.z != SecondEnd.z)
        {
            zave = (firstEnd.z + SecondEnd.z) / 2;
            myOwnLocation.position = new Vector3(myOwnLocation.position.x,myOwnLocation.position.y , zave);
           
        }
        if (firstEnd.x != SecondEnd.x)
        {
            xave = (firstEnd.x + SecondEnd.x) / 2;
            myOwnLocation.position = new Vector3(xave, myOwnLocation.position.y, myOwnLocation.position.z);
            
        }

      
        
    }
    //-1.049042e-05
    //1.359134
    //7.346566
    //8.7057

    /*
    RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, 4))
        {
        */
}
