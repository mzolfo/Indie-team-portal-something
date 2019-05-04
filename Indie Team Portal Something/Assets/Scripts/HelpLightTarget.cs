using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpLightTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject targetHelpLight;
    private Light myOwnLight;
    [SerializeField]
    private MeshRenderer MyHelpLightRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myOwnLight = GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetHelpLight.activeInHierarchy)
        {
            myOwnLight.range = 35;
            MyHelpLightRenderer.enabled = true;
        }
    }
}
