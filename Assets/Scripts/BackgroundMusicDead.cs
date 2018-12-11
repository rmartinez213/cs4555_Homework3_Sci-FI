using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicDead : MonoBehaviour {

    public static AudioSource myAudioDying;

    // Use this for initialization
    void Start () {

        myAudioDying = GetComponent<AudioSource>();
        

    }

    public static void PlayMusic(){
        myAudioDying.clip = Resources.Load<AudioClip>("Background_dying");
        myAudioDying.ignoreListenerVolume = true;
        myAudioDying.ignoreListenerPause = true;
        myAudioDying.volume = 1;

        myAudioDying.Play();
    }

    public static void StopMusic(){
        myAudioDying.clip.UnloadAudioData();
        myAudioDying.Stop();
    }


    // Update is called once per frame
    void Update () {
		
	}
}
