using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackGroundCycle : MonoBehaviour
{
    //this script only triggers the black fadeout when the animation clips demand it
    public enum CurrentRoom { Greenhouse, GrandHall, Library, DivinationTower }
    private CurrentRoom myCurrentRoom = CurrentRoom.Greenhouse;
    private Animator myAnimator;

    [SerializeField]
    private Animator BlackPlateAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToBlack()
    {
        BlackPlateAnimator.SetBool("Fading", true);
        BlackPlateAnimator.SetBool("Black", true);
    }

    public void EndFrame()
    {
        if (myCurrentRoom == CurrentRoom.Greenhouse)
        {
            myAnimator.SetInteger("CurrentRoom", 1);
            myCurrentRoom = CurrentRoom.GrandHall;
        }
        else if (myCurrentRoom == CurrentRoom.GrandHall)
        {
            myAnimator.SetInteger("CurrentRoom", 2);
            myCurrentRoom = CurrentRoom.Library;
        }
        else if (myCurrentRoom == CurrentRoom.Library)
        {
            myAnimator.SetInteger("CurrentRoom", 3);
            myCurrentRoom = CurrentRoom.DivinationTower;
        }
        else if (myCurrentRoom == CurrentRoom.DivinationTower)
        {
            myAnimator.SetInteger("CurrentRoom", 0);
            myCurrentRoom = CurrentRoom.Greenhouse;
        }
        BlackPlateAnimator.SetBool("Black", false);
    }

}
