using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseAndMenuLogic : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject pauseMenu;
    [SerializeField]
    private Button ResumeButton;
    [SerializeField]
    private Button ExitButton;
    [SerializeField]
    private GameObject greyPlate;


    //private GameObject PauseInstruction;



    void Start()
    {
        ResumeGame();
        ResumeButton.onClick.AddListener(ResumeGame);
        ExitButton.onClick.AddListener(PauseGame);
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
        greyPlate.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        greyPlate.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

    }

    public void ExitGame()
    {
        //this should be changed to return to main menu when it is made
        Application.Quit();
    }
    
}
