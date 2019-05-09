using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonGoBetween : MonoBehaviour
{
    //this is to check fi an image's parent button is highlighted by the mouse and animate when it is.

    private Animator myAnimator;
    private Sprite MystartSprite;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        MystartSprite = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayAnimationOnHover()
    {
        myAnimator.SetBool("MouseIsOver", true);
    }
    public void StopAnimation()
    {
        myAnimator.SetBool("MouseIsOver", false);
        GetComponent<Image>().sprite = MystartSprite;
    }
}
