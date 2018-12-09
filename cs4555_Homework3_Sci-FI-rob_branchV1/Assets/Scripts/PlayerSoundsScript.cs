using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundsScript : MonoBehaviour {

    //Sound Source
    [SerializeField] private AudioSource soundSource; //player object
    [SerializeField] private AudioClip jetpackSound; //audio clip


    // Use this for initialization
    void Start () {
		
	}


	
	// Update is called once per frame
	void Update () {

        //Debug.Log("Vertical Velocity is: " + FPSInput.verticalVelocity);

        if(FPSInput.verticalVelocity > 5 && !soundSource.isPlaying){
            soundSource.PlayOneShot(jetpackSound);
          //  Debug.Log("Play Sound Plz");
        }

        else if(FPSInput.verticalVelocity < 5 && soundSource.isPlaying){
            soundSource.Stop();
        }
	}
}
