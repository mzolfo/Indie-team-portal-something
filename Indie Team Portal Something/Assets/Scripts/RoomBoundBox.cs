using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBoundBox : MonoBehaviour
{
   
    private CurrentRoomCheck playerRoomTracker;
    [SerializeField]
    private CurrentRoom MyAssignedRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerRoomTracker = other.GetComponent<CurrentRoomCheck>();
            playerRoomTracker.BeAssignedNewCurrentRoom(MyAssignedRoom);
        }
    }
}
