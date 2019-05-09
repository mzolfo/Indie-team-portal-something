using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public bool EndgameBegun;
    [SerializeField]
    private List<Image> ButtonImages;

    [SerializeField]
    private Sprite ProperSource;

    //private GameObject PauseInstruction;



    void Start()
    {
        PauseGame();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!EndgameBegun)
        {
            if (Input.GetButtonDown("Pause"))
            {

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
        updateImagesToOriginalEnvelope();
        if (!EndgameBegun)
        {
            pauseMenu.SetActive(true);
        }
       
        Time.timeScale = 0f;
        Paused = true;
        greyPlate.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       

    }

    public void ExitGame()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }

    void updateImagesToOriginalEnvelope()
    {
        for (int i = 0; i < ButtonImages.Count; i++)
        {
            ButtonImages[i].sprite = ProperSource;
        }
    }
}
