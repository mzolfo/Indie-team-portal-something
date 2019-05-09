using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour {
    [SerializeField]
    private Transform PlayerTransform;
    [SerializeField]
    private float speedH = 2.0f;
    [SerializeField]
    private float speedV = 2.0f;
    private float yRotationOffset;

    public bool lockCursor = true;

    private bool m_cursorIsLocked;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public bool EndgameBegun = false;
   
    
	// Use this for initialization
	void Start () {
        m_cursorIsLocked = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!EndgameBegun)
        {
            if (!PauseAndMenuLogic.Paused)
            {
                yRotationOffset = PlayerTransform.eulerAngles.y;
                yaw += speedH * Input.GetAxis("Mouse X");
                pitch -= speedV * Input.GetAxis("Mouse Y");

                if (pitch > 50)
                {
                    pitch = 50f;
                }
                else if (pitch < -50)
                {
                    pitch = -50f;
                }

                transform.eulerAngles = new Vector3(pitch, yaw + yRotationOffset, 0.0f);
                
            }
        }
        UpdateCursorLock();
        if (EndgameBegun)
        { m_cursorIsLocked = false; }

    }


    


    public void UpdateCursorLock()
    {
        //if the user set "lockCursor" we check & properly lock the cursor
        if (lockCursor)
            InternalLockUpdate();
    }

    private void InternalLockUpdate()
    {
        if (PauseAndMenuLogic.Paused)
        {
            m_cursorIsLocked = false;
        }
        else
        {
            m_cursorIsLocked = true;
        }
        /*
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }
        */
        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

} 