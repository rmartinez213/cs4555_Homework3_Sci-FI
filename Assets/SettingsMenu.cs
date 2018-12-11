using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;
    public Slider volSlider;

    void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("MVolume");
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
    }


    public void SetVolume(float volume){
        //Debug.Log(volume);
        PlayerPrefs.SetFloat("MVolume", volume);

        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("MVolume"));
    }
}
