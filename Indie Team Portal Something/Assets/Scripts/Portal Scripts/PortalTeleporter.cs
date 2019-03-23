using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    private Rigidbody playerRigidbody;
   

    public bool playerNotToTeleport;

    [SerializeField]
    private bool playerIsOverlapping = false;
    [SerializeField]
    float exposeRotationDiff;
    [SerializeField]
    private PortalTeleporter otherPortalScript;
    
    public int PlayerToTeleportDelay = 0;

    //how can we tell the colliderbox to check if the player just came from another one.
    //just send a variable to the other one's script telling it to turn on dont teleport the player right now.
    //how can we tell the other one when to teleport the player again...
    //

    //playernottoteleport cant be on the player's script. it needs to be specific to the portal he is going to.


    //note: we want something behind each portal so the player can't just slide through it if the collider box isnt there.

    private void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerNotToTeleport)
        {
            PlayerToTeleportDelay = PlayerToTeleportDelay - 1;
            if (PlayerToTeleportDelay == 0)
            {
                playerNotToTeleport = false;
            }
        }
        else
        { 
            if (playerIsOverlapping)
            {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // If this is true: The player has moved across the portal
                if (dotProduct < 0f)
                {
                //Teleport him!
                    float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                    rotationDiff += 180;
                    exposeRotationDiff = rotationDiff;
                    player.Rotate(Vector3.up, rotationDiff);
                    
                    if (rotationDiff == 180)
                    {
                        Vector3 entryDirection = playerRigidbody.velocity.normalized;
                        float entrySpeed = playerRigidbody.velocity.magnitude;
                        Vector3 newDirection = new Vector3(-entryDirection.x * 2, entryDirection.y, -entryDirection.z * 2);
                        playerRigidbody.velocity = newDirection.normalized * entrySpeed;
                    }
                    
                    
                    /*
               entryVector = new Vector3(-entryVector.x, entryVector.y, -entryVector.z);

                   player.GetComponent<Rigidbody>().velocity = entryVector;
                   */
                    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                    player.position = reciever.position + positionOffset;
                    Debug.Log("Player has been Teleported");
                    playerIsOverlapping = false;
                    otherPortalScript.playerNotToTeleport = true;
                    otherPortalScript.PlayerToTeleportDelay = 50;
                 }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
             playerIsOverlapping = true; 
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
            //playerScript.playerNotToTeleport = false;
        }
    }

    public void ChangeDestinationPortal(Transform NewTargetTransform)
    {
        reciever = NewTargetTransform;
        otherPortalScript = NewTargetTransform.GetComponent<PortalTeleporter>();
    }
}
