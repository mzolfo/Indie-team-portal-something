using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailBoxEndstateManager : MonoBehaviour
{
    //this is facilitating a series of events in order over time

    //when box is interacted with begin fade to black
    //then remove control from player and activate rigidbody on wizard cutout, turn on box to be thrown.
    //then position them for their exit animation
    //then fade in
    //then play players animation
    //a few frames in activate box throw script
    //after it falls cut to black and begin credit screen?

        //we need an animation for the camera and one that has a number of triggers on it.


    [SerializeField]
    private GameObject DeliveryBox;
    [SerializeField]
    private GameObject playerCamera;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject EndgameCamera;
    [SerializeField]
    private Rigidbody wizardCutoutRigidbody;
    private AudioSource myAudioSource;
    
    [SerializeField]
    private Animator blackPlate;
    



    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginEndState() //player has interacted with the mailbox begin endstate
    {
        playerCamera.GetComponent<CameraMotion>().EndgameBegun = true;
        blackPlate.SetBool("Fading", true);
        blackPlate.SetBool("Black", true);
        //trigger the animator of the blackplate to begin fade to black

        //when animator returns endframe return here.
    }

    public void FadedToBlack()
    {
        wizardCutoutRigidbody.isKinematic = false;
        DeliveryBox.SetActive(true);
        playerCamera.SetActive(false);
        EndgameCamera.SetActive(true);
        Player.SetActive(false);
        blackPlate.SetBool("Black", false);
        //then remove control from player and activate rigidbody on wizard cutout, turn on box to be thrown.
        //then position them for their exit animation
        //then fade in
    }
    public void FadedFromBlack()
    {
        EndgameCamera.GetComponent<Animator>().SetBool("BeginThrow", true);
        //then play players animation
        //a few frames in activate box throw script
        //after it falls cut to black and begin credit screen?
    }

    public void ThrowBox()
    {
        DeliveryBox.GetComponent<Rigidbody>().isKinematic = false;
        DeliveryBox.GetComponent<BoxThrow>().ThrowSelf();
        myAudioSource.Play();
    }

    public void CutToBlack()
    {
        blackPlate.SetBool("Cut", true); //follow this with whatever we need for the actual end of the game.       
    }
}
