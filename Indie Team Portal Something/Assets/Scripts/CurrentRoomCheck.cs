using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCheck : MonoBehaviour
{
    public bool isInGrandHall = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePlayerinGrandHall()
    {
        if (isInGrandHall)
        {
            isInGrandHall = false;
        }
        else { isInGrandHall = true; }
    }
}
