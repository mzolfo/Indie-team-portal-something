using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{ //look into this it needs to change as the list gets longer and the targets differ i believe
   

    public List<Camera> cameras;
    public List<Material> cameraMats;
    /*
    public Camera camera2;
    public Camera camera1;
    public Camera camera3;
    public Camera camera4;
    public Material cameraMat2;
    public Material cameraMat1;
    public Material cameraMat3;
    public Material cameraMat4;
    */
    // Start is called before the first frame update
    void Start()
    {
        UpdateCameraRenderTexture();

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCameraRenderTexture()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            if (cameras[i].targetTexture != null)
            {
                cameras[i].targetTexture.Release();
            }
            cameras[i].targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            cameraMats[i].mainTexture = cameras[i].targetTexture;


        }
        /*
        if (camera1.targetTexture != null)
            {
                camera1.targetTexture.Release();
            }
            camera1.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            cameraMat1.mainTexture = camera1.targetTexture;

            if (camera2.targetTexture != null)
            {
                camera2.targetTexture.Release();
            }
            camera2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            cameraMat2.mainTexture = camera2.targetTexture;

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
            */
        }

    }


