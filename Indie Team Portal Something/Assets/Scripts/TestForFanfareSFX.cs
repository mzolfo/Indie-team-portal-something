using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForFanfareSFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource PlayerFanfareAudio;

    [SerializeField]
    private AssociatedPortalData greenhouseDiorama;
    [SerializeField]
    private AssociatedPortalData libraryDiorama;
    [SerializeField]
    private AssociatedPortalData divinationTowerDiorama;

    [SerializeField]
    private ContextualPosition stairWayKeyhole;
    [SerializeField]
    private ContextualPosition BookLocation1;
    [SerializeField]
    private SummoningCirclePuzzleLogic summoningCircle;

    private int greenhousePosition;
    private int libraryPosition;
    private int divinationTowerPosition;

    private bool grandHallForcefieldSolved = false;
    private bool libraryMazeBegun = false;
    private bool libraryMazeSolved = false;
    private bool libraryForcefieldSolved = false;
    private bool summoningCircleSolved = false;
    private bool divinationPositioningSolved = false;
    private bool packageDelivered = false;
    //1 and 3 are adjacent and 5 and 7 are adjacent
    
    //the associated portal data script has a value for myPosition that tells which slot the diorama is placed in.

    //this needs to know when the player has accomplished a task for the larger progression of the game and play a sound attached to them if they have.

    //conditions by which this will activate
    //when placing the first and last book in the book maze
    //when placing the greenhouse in the correct spot during the first puzzle in the grand hall. (position 5)
    //when picking up a crate for the first time?
    //when placing the library adjacent to the greenhouse after having completed the puzzle maze. 
    //when placing the divination tower adjacent to another diorama for the first time. (either 1 and 3 or 5 and 7)
    //when activating the final dropbox


        //what does this need access to 
        //the locations of each placed diorama
        //the keyinplace component of each relevant key location.


        //we largely want these to happen in order. 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        greenhousePosition = greenhouseDiorama.myPosition;
        libraryPosition = libraryDiorama.myPosition;
        divinationTowerPosition = divinationTowerDiorama.myPosition;

        if (!grandHallForcefieldSolved)
        {
            CheckGrandHallForcefieldSolved();
        }
        if (!libraryMazeBegun)
        {
            CheckLibraryMazeBegun();
        }
        if (!libraryMazeSolved)
        {
            CheckLibraryMazeSolved();
        }
        if (!libraryForcefieldSolved)
        {
            CheckLibraryForcefieldSolved();
        }
        if (!summoningCircleSolved)
        {
            CheckSummoningCircleSolved();
        }
        if (!divinationPositioningSolved)
        {
            CheckDivinationPositioningSolved();
        }
        //if (!packageDelivered)
        //{
       //     CheckPackageDelivered();
       // }
    }

    void TriggerPuzzleSolvedEffect()
    {
        PlayerFanfareAudio.Play();
    }


    void CheckGrandHallForcefieldSolved()
    {
        if (greenhousePosition == 5)
        {
            TriggerPuzzleSolvedEffect();
            grandHallForcefieldSolved = true;
        }
    }

    void CheckLibraryMazeBegun()
    {
        if (BookLocation1.keyInPlace)
        {
            TriggerPuzzleSolvedEffect();
            libraryMazeBegun = true;
        }
    }

    void CheckLibraryMazeSolved()
    {
        if (stairWayKeyhole.keyInPlace)
        {
            TriggerPuzzleSolvedEffect();
            libraryMazeSolved = true;
        }
    }

    void CheckLibraryForcefieldSolved()//(either lib1 greenhouse3 or lib7 greenhouse5)
    {
        if (libraryMazeSolved)
        {
            if (libraryPosition == 1 && greenhousePosition == 3)
            {
                TriggerPuzzleSolvedEffect();
                libraryForcefieldSolved = true;
            }
            else if (libraryPosition == 7 && greenhousePosition == 5)
            {
                TriggerPuzzleSolvedEffect();
                libraryForcefieldSolved = true;
            }
        }
    }

    void CheckSummoningCircleSolved()
    {
        if (summoningCircle.hasBeenSolved)
        {
            TriggerPuzzleSolvedEffect();
            summoningCircleSolved = true;
        }
    }

    void CheckDivinationPositioningSolved()
    {
        if (divinationTowerPosition == 1)
        {
            if (libraryPosition == 3 || greenhousePosition == 3)
            {
                TriggerPuzzleSolvedEffect();
                divinationPositioningSolved = true;
            }
        }
        else if (divinationTowerPosition == 3)
        {
            if (libraryPosition == 1 || greenhousePosition == 1)
            {
                TriggerPuzzleSolvedEffect();
                divinationPositioningSolved = true;
            }
        }
        else if (divinationTowerPosition == 5)
        {
            if (libraryPosition == 7 || greenhousePosition == 7)
            {
                TriggerPuzzleSolvedEffect();
                divinationPositioningSolved = true;
            }
        }
        else if (divinationTowerPosition == 7)
        {
            if (libraryPosition == 5 || greenhousePosition == 5)
            {
                TriggerPuzzleSolvedEffect();
                divinationPositioningSolved = true;
            }
        }
    }

    void CheckPackageDelivered()
    {
        //INCOMPLETE
        //needs implemented conditions by which the package can be found as delivered.
    }

}

