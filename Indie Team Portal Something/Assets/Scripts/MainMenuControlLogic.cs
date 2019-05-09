using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControlLogic : MonoBehaviour
{

    //start button needs to move us to the actual game in demoscene
    [SerializeField]
    private GameObject Credits;
    [SerializeField]
    private GameObject CreditsBackButton;
    [SerializeField]
    private List<GameObject> MenuItems;
    [SerializeField]
    private List<Image> ButtonImages;
    [SerializeField]
    private Sprite ProperSource;
    //exit button close program
    //credits closes menu and make back button appear, back button closes credits and makes menu appear.
    // Start is called before the first frame update

    private void Update()
    {
        if (Cursor.lockState != CursorLockMode.None || !Cursor.visible)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void StartButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditsButtonPressed()
    {
        for (int i = 0; i < MenuItems.Count; i++)
        {
            MenuItems[i].SetActive(false);
        }
        Credits.SetActive(true);
        CreditsBackButton.SetActive(true);
        updateImagesToOriginalEnvelope();
    }

    public void CreditsBackButtonPressed()
    {
        for (int i = 0; i < MenuItems.Count; i++)
        {
            MenuItems[i].SetActive(true);
        }
        Credits.SetActive(false);
        CreditsBackButton.SetActive(false);
        updateImagesToOriginalEnvelope();
    }

    public void ExitButtonPressed()
    {
        Application.Quit();
    }

    void updateImagesToOriginalEnvelope()
    {
        for (int i = 0; i < ButtonImages.Count; i++)
        {
            ButtonImages[i].sprite = ProperSource;
        }
    }
}
