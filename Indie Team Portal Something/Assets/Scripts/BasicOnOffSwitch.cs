using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicOnOffSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject ObjectToBeManipulated;
    //make this a list and make the stuff below work with lists.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleActiveStateOfTarget()
    {
        if (ObjectToBeManipulated.activeInHierarchy)
        {
            ObjectToBeManipulated.SetActive(false);
        }
        else { ObjectToBeManipulated.SetActive(true); }
    }
}
