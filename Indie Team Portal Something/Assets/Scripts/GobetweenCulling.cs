using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobetweenCulling : MonoBehaviour
{
    [SerializeField]
    private CullingForRenderPlanes myRenderPlaneScript;
    public bool renderPlaneIsActive;
    // Start is called before the first frame update
    void Start()
    {
        myRenderPlaneScript = GetComponentInChildren<CullingForRenderPlanes>();
    }

    // Update is called once per frame
    void Update()
    {
        renderPlaneIsActive = myRenderPlaneScript.renderPlaneIsActive;
    }
}
