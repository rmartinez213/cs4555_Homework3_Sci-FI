using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    public static AudioSource myAudio;
   

    void Awake() {
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = Resources.Load<AudioClip>("Background_horror");
        myAudio.ignoreListenerVolume = true;
        myAudio.ignoreListenerPause = true;
        myAudio.volume = 1;
    }

    public static void PlayMusic(){
        myAudio.Play();
    }

    public static void StopMusic()
    {
        myAudio.clip.UnloadAudioData();
        myAudio.Stop();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
