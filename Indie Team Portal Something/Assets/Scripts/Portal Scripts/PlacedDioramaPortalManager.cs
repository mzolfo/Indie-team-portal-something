using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedDioramaPortalManager : MonoBehaviour
{
    //this needs to keep information about appropriate links to pass to the portal switcher 
    //based on which portals are meant to be connected according to placed diorama objects.

    [SerializeField]
    private GameObject PortalSwitchManager;

    private PortalSwitcher worldPortalSwitcher;
    private PortalDeactivator portalSwitchDeactivator;

    [SerializeField]
    private List<ContextualPosition> PossiblePositions;
    //each position can pair with its adjacent, we need to know if each paired position has a diorama in it
    //if so we need to know if those adjacents each have side portals
    //if so we need to know which ones.
    private int foundAdjacentSidePortal;
    private bool rightToLeft;

    //for side portals
    //1's left pairs with 3's right
    //5's left pairs with 7's right


    //each object's associated portal's numbers are stored as ints on an associatedportaldata script
    //this script must collect the data from each location placed in and each diorama placed upon to 
    //find appropriate links and call them.


    //current possible dioramas are
    //greenhouse with downstairs 2 and upstairs 8
    //library with downstairs 6 and upstairs 12 and left side 18 and right side 19
    //divination tower with downstairs 4 and upstairs 10 and left side 17 and right side 16

    //current drop locations are
    //1 with downstairs 1 upstairs 9
    //3 with downstairs 3 and upstairs 11
    //5 with downstairs 5 and upstairs 13
    //7 with downstairs 7 and upstairs 15

    // Start is called before the first frame update
    void Start()
    {
        worldPortalSwitcher = PortalSwitchManager.GetComponent<PortalSwitcher>();
        portalSwitchDeactivator = PortalSwitchManager.GetComponent<PortalDeactivator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this script needs to know which dioramas have been placed where.


    public void CheckDioramaPlaced(AssociatedPortalData PositionData, AssociatedPortalData DioramaData)
    {
        if (PositionData.upStairs != 0 && DioramaData.upStairs != 0)
        {
            worldPortalSwitcher.BeginSwitch(PositionData.upStairs, DioramaData.upStairs);
        }
        if (PositionData.downStairs != 0 && DioramaData.downStairs != 0)
        {
            worldPortalSwitcher.BeginSwitch(PositionData.downStairs, DioramaData.downStairs);
        }

        if (CheckSideDioramaNeedsAction(PositionData, DioramaData))
        {
            if (rightToLeft)
            {
                worldPortalSwitcher.BeginSwitch(DioramaData.rightSide, foundAdjacentSidePortal);
            }
            else { worldPortalSwitcher.BeginSwitch(DioramaData.leftSide, foundAdjacentSidePortal); }
            rightToLeft = false;
            foundAdjacentSidePortal = 0;
        }
        else { return; }
        //when a diorama is placed we need to connect its portals to the grand hall/side portals necessary
        //first we attach the top and bottom floors of the diorama to the grand hall
    }

    public void CheckDioramaRemoved(AssociatedPortalData PositionData, AssociatedPortalData DioramaData)
    {
        if (PositionData.upStairs != 0)
        {
            portalSwitchDeactivator.DeactivateTargetPortal(PositionData.upStairs);
        }
        if (PositionData.downStairs != 0)
        {
            portalSwitchDeactivator.DeactivateTargetPortal(PositionData.downStairs);
        }
        if (DioramaData.upStairs != 0)
        {
            portalSwitchDeactivator.DeactivateTargetPortal(DioramaData.upStairs);
        }
        if (DioramaData.downStairs != 0)
        {
            portalSwitchDeactivator.DeactivateTargetPortal(DioramaData.downStairs);
        }
        if (DioramaData.leftSide != 0)
        {
            portalSwitchDeactivator.DeactivateTargetPortal(DioramaData.leftSide);
        }
        if (DioramaData.rightSide != 0)
        {
            portalSwitchDeactivator.DeactivateTargetPortal(DioramaData.rightSide);
        }

        if (CheckSideDioramaNeedsAction(PositionData, DioramaData))
        {
            portalSwitchDeactivator.DeactivateTargetPortal(foundAdjacentSidePortal);
            foundAdjacentSidePortal = 0;
            rightToLeft = false;
        }
        //we need to check if the left/right sides were linked to another portal and deactivate it as well.
    }

    bool CheckSideDioramaNeedsAction(AssociatedPortalData positionData, AssociatedPortalData DioramaData)
    { //positions are adjacent if they are 1-3 or 5-7
        if (DioramaData.leftSide != 0 || DioramaData.rightSide != 0) //if the placed diorama has sides
        {
            if (PossiblePositions[findAdjacentPosition(DioramaData.myPosition)].myAssignedObject != null) //if there is a diorama adjacent
            {
                AssociatedPortalData adjacentDioramaData = PossiblePositions[findAdjacentPosition(DioramaData.myPosition)].GetAttachedObjectPortalData();
                if (adjacentDioramaData.leftSide != 0 || adjacentDioramaData.rightSide != 0) //if the adjacent diorama has sides
                {
                    if (rightToLeft) //does the original portal link its right side to the adjacent left or vice versa;
                    {
                        foundAdjacentSidePortal = adjacentDioramaData.leftSide;
                    }
                    else { foundAdjacentSidePortal = adjacentDioramaData.rightSide; }
                    return true;
                }
                else { return false; }
            }
            else { return false; }
           // findAdjacentPosition(DioramaData.myPosition);
        }
        else { return false; }
       
    }

    int findAdjacentPosition(int CurrentPosition)
    {
        if (CurrentPosition == 1)
        {
            rightToLeft = true;
            return 1;
        }
        else if (CurrentPosition == 3)
        {
            rightToLeft = false;
            return 0;
        }
        else if (CurrentPosition == 5)
        {
            rightToLeft = false;
            return 3;
        }
        else if (CurrentPosition == 7)
        {
            rightToLeft = true;
            return 2;
        }
        else
        { rightToLeft = false; return -1;  }
    }
}
