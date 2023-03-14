using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSet : MonoBehaviour
{

    public AudioMixer mixer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetMusicVol(float sliderVal)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderVal) * 20);
        PlayerPrefs.SetFloat("mVol", Mathf.Log10(sliderVal) * 20);
    }
}
