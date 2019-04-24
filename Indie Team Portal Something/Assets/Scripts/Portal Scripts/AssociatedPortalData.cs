using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssociatedPortalData : MonoBehaviour
{
    //this acts as a space to store an object's associated portals

    public int myPosition;
    public int upStairs;
    public int downStairs;
    public int leftSide;
    public int rightSide;


    

    //left and right side are determined by the appropriate oriention when looking out the exit door.
    //if the player is in the room looking out the door to the grand hall, rightside is to their right and left side is to their left.
    //current possible dioramas as of 4/24/19 are
    //greenhouse with downstairs 2 and upstairs 8
    //library with downstairs 6 and upstairs 12 and left side 18 and right side 19
    //divination tower with downstairs 4 and upstairs 10 and left side 17 and right side 16

    //current drop locations are
    //1 with downstairs 1 upstairs 9
    //3 with downstairs 3 and upstairs 11
    //5 with downstairs 5 and upstairs 13
    //7 with downstairs 7 and upstairs 15


}
