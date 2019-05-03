using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class DoorAnimationLogic : MonoBehaviour
{

    public enum State { Open, Closed, Opening, Closing}

    public State myState;
    [SerializeField]
    private Animator DoorAnimator;
    [SerializeField]
    private BoxCollider OpenCollider;
    [SerializeField]
    private BoxCollider ClosedCollider;
    private AudioSource myAudioSource;
    [SerializeField]
    private AudioClip OpeningClip;
    [SerializeField]
    private AudioClip ClosingClip;

    [SerializeField]
    private GameObject AssociatedPortalColliderPlane;

    // Start is called before the first frame update
    void Start()
    {
        DoorAnimator = GetComponent<Animator>();
        myState = State.Closed;
        if (GetComponent<AudioSource>() != null)
        {
            myAudioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckAssociatedPortalState();
        UpdateAnimatorToCurrentState();

    }

    private void CheckAssociatedPortalState()
    {
        if (AssociatedPortalColliderPlane.activeInHierarchy && myState == State.Closed)
        {
            myState = State.Opening;
            if (myAudioSource != null)
            {
                myAudioSource.clip = OpeningClip;
                myAudioSource.Play();
            }
           
        }
        else if (!AssociatedPortalColliderPlane.activeInHierarchy && myState == State.Open)
        {
            myState = State.Closing;
           
        }
    }

    private void UpdateAnimatorToCurrentState()
    {
        if (myState == State.Closed)
        {
            DoorAnimator.SetInteger("State", 0);
            if (!ClosedCollider.enabled || OpenCollider.enabled)
            { ClosedCollider.enabled = true; OpenCollider.enabled = false; }
        }
        else if (myState == State.Opening)
        {
            DoorAnimator.SetInteger("State", 1);
            if (ClosedCollider.enabled || !OpenCollider.enabled)
            { ClosedCollider.enabled = false; OpenCollider.enabled = true; }
        }
        else if (myState == State.Open)
        {
            DoorAnimator.SetInteger("State", 2);
            if (ClosedCollider.enabled || !OpenCollider.enabled)
            { ClosedCollider.enabled = false; OpenCollider.enabled = true; }
        }
        else if (myState == State.Closing)
        {
            DoorAnimator.SetInteger("State", 3);
            if (!ClosedCollider.enabled || OpenCollider.enabled)
            { ClosedCollider.enabled = true; OpenCollider.enabled = false; }
        }
    }

    public void Endframe()
    {
        MoveToStaticState();
    }

    private void MoveToStaticState()
    {
        if (myState == State.Opening)
        {
            myState = State.Open;
        }
        else if (myState == State.Closing)
        {
            myState = State.Closed;
            if (myAudioSource != null)
            {
                myAudioSource.clip = ClosingClip;
                myAudioSource.Play();
            }
            
        }
    }

}
