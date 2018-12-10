//Game Programming HW1 
//=======================================================================================
// Name        : Health_Pickup.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Script that is attached to crates where player can walk to it and heal up
//========================================================================================

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Key_Pickup : MonoBehaviour
{
    public Transform other;
    public float closeDistance = 0.5F;
	public static bool key = false;
    private bool soundPlayed = true;

    //Audio Source Code
    [SerializeField] private AudioSource soundSource; //player object
    [SerializeField] private AudioClip itemPickupSound; //audio clip

    //KeyCard RawImage
    public RawImage keycardImage; //rawImage


    void Start(){
        keycardImage.gameObject.SetActive(false);
    }

    void Update()
    {
        if (other)
        {
            Vector3 offset = other.position - transform.position;
            float sqrLen = offset.sqrMagnitude;
            if (sqrLen < closeDistance * closeDistance){
                if (!soundSource.isPlaying){
                    if (soundPlayed){
                        //Sound play
                        soundSource.PlayOneShot(itemPickupSound);
                        soundPlayed = false;
                        keycardImage.gameObject.SetActive(true);
                    }
                }
                
                //Set key value to true, so it can open door
                key = true;
				Debug.Log("You obtained the key");
            }

            if(!soundSource.isPlaying && !soundPlayed){
                //Set Active to false, so it can be set to true when restarting game
                this.gameObject.SetActive(false);
            }
        }
    }

    public void KeyReset()
    {
        keycardImage.gameObject.SetActive(false);
        soundPlayed = true;
		key = false;
        this.gameObject.SetActive(true);
    }
}