using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeShelf2CutSoundEffect : MonoBehaviour
{
    private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndFrame()
    {
        myAudioSource.Stop();
    }
}
