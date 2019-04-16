using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentRoom { GreenHouse, Library, GrandHall, Laboratory, DivinationTower, Outside }
public class CurrentRoomCheck : MonoBehaviour
{

    public CurrentRoom myCurrentRoom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeAssignedNewCurrentRoom(CurrentRoom NewRoom)
    {
        myCurrentRoom = NewRoom;
    }

    
}
