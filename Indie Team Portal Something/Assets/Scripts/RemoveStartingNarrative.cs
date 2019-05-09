using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveStartingNarrative : MonoBehaviour
{
    [SerializeField]
    private PauseAndMenuLogic PauseControl;
    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0"))
        {
            PauseControl.ResumeGame();
            Destroy(this.gameObject);
        }
    }
}
