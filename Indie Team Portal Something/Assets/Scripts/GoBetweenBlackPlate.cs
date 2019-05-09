using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoBetweenBlackPlate : MonoBehaviour
{
    [SerializeField]
    private MailBoxEndstateManager mailBox;
   

    //this is a gobetween script to pass to the mailBoxEndStateManager that the black plate is finished fading in/out.

    public void FadedToBlack()
    {
        if (mailBox != null)
        {
            mailBox.FadedToBlack();
        }
       
    }
    public void FadedFromBlack()
    {
        if (mailBox != null)
        {
            mailBox.FadedFromBlack();
           
        }
        GetComponent<Animator>().SetBool("Fading", false);

    }
    public void HasCutToBlack()
    {

    }
}
