using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicOnOffSwitch : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ObjectsToBeManipulated;
    [SerializeField]
    private Material OnColor;
    [SerializeField]
    private Material OffColor;
    private bool ObjectIsOn = true;
    private Material MyCurrentMaterial;

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
            if (g.activeInHierarchy) { g.SetActive(false); ObjectIsOn = false; }
            else { g.SetActive(true); ObjectIsOn = true; }
        }
        ToggleOwnColorState();
    }
    private void ToggleOwnColorState()
    {
        if (!ObjectIsOn)
        {
            GetComponent<MeshRenderer>().material = OffColor;
        }
        else
        {
            GetComponent<MeshRenderer>().material = OnColor;
        }
    }

}
