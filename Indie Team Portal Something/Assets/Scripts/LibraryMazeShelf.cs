using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryMazeShelf : MonoBehaviour
{

    [SerializeField]
    private ContextualPosition myContextualPosition;
    private bool animationHasBegun = false;
    private Animator myAnimator;
    [SerializeField]
    private AudioSource SecondaryAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myContextualPosition.keyInPlace)
        {
            if (!animationHasBegun)
            {
                BeginAnimation();
            }
        }
    }

    private void BeginAnimation()
    {
        myAnimator.SetBool("PlayAnimation", true);
        animationHasBegun = true;
        
    }

    public void EndFrame()
    {
    } 

    public void TriggerSound()
    {
            myContextualPosition.TriggerSound();
        
    }

    public void TriggerSecondarySound()
    {
        if (SecondaryAudioSource != null)
        {
            SecondaryAudioSource.Play();
        }
    }
    
}
