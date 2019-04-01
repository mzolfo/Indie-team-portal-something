using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationLogic : MonoBehaviour
{

    public enum State { Open, Closed, Opening, Closing}

    public State myState;
    [SerializeField]
    private Animator DoorAnimator;

    [SerializeField]
    private GameObject AssociatedPortalColliderPlane;

    // Start is called before the first frame update
    void Start()
    {
        DoorAnimator = GetComponent<Animator>();
        myState = State.Closed;
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
        }
        else if (!AssociatedPortalColliderPlane.activeInHierarchy && myState == State.Open)
        {
            myState = State.Closing;
        }
    }

    private void UpdateAnimatorToCurrentState()
    {
        if (myState == State.Closed)
        { DoorAnimator.SetInteger("State", 0); }
        else if (myState == State.Opening)
        { DoorAnimator.SetInteger("State", 1); }
        else if (myState == State.Open)
        { DoorAnimator.SetInteger("State", 2); }
        else if (myState == State.Closing)
        { DoorAnimator.SetInteger("State", 3); }
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
        }
    }

}
