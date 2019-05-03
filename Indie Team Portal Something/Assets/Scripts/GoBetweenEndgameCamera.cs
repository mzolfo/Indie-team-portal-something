using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBetweenEndgameCamera : MonoBehaviour
{

    [SerializeField]
    private MailBoxEndstateManager MailBox;

    public void ThrowBox()
    {
        MailBox.ThrowBox();
    }

    public void Endframe()
    {
        MailBox.CutToBlack();
    }
}
