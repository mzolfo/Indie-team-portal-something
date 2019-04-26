﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseAndMenuLogic : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject pauseMenu;
    


    //private GameObject PauseInstruction;



    void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            //if (PauseInstruction.activeSelf)
           // {
            //    PauseInstruction.SetActive(false);
           // }
            if (Paused)
            {
                ResumeGame();
                Debug.Log("Player resumed gameplay.");
            }

            else
            {
                PauseGame();
                Debug.Log("Player paused the game.");
            }

        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }

    public void ExitGame()
    {
        //this should be changed to return to main menu when it is made
        Application.Quit();
    }
    
}