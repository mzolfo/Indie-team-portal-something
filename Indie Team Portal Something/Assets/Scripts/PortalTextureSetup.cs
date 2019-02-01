using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraB;
    public Camera cameraA;
    public Camera camera3;
    public Camera camera4;

    public Material cameraMatB;
    public Material cameraMatA;
    public Material cameraMat3;
    public Material cameraMat4;
    // Start is called before the first frame update
    void Start()
    {

        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = cameraA.targetTexture;

        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;

        if (camera3.targetTexture != null)
        {
            camera3.targetTexture.Release();
        }
        camera3.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat3.mainTexture = camera3.targetTexture;

        if (camera4.targetTexture != null)
        {
            camera4.targetTexture.Release();
        }
        camera4.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat4.mainTexture = camera4.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
