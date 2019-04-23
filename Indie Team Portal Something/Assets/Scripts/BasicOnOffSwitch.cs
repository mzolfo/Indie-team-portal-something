using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicOnOffSwitch : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ObjectsToBeManipulated;

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
        foreach (GameObject g in ObjectsToBeManipulated)
        {
            if (g.activeInHierarchy) { g.SetActive(false); }
            else { g.SetActive(true); }
        }
    }
}
