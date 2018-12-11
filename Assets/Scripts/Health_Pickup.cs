//Game Programming HW1 
//=======================================================================================
// Name        : Health_Pickup.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Script that is attached to crates where player can walk to it and heal up
//========================================================================================

using UnityEngine;
using System.Collections;
public class Health_Pickup : MonoBehaviour
{
    public Transform other;
    public float closeDistance = 0.5F;

    //Audio Source Code
    [SerializeField] private AudioSource soundSource; //player object
    [SerializeField] private AudioClip healthPickupSound; //audio clip
    private bool soundPlayed = true;

    void Update()
    {
        if (other)
        {
            Vector3 offset = other.position - transform.position;
            float sqrLen = offset.sqrMagnitude;
            if (sqrLen < closeDistance * closeDistance)
            {

                if (!soundSource.isPlaying){
                    if (soundPlayed){
                        //Sound play
                        soundSource.PlayOneShot(healthPickupSound);
                        soundPlayed = false;
                    }
                }
            }

            if(!soundSource.isPlaying && !soundPlayed){
                //Set Active to false, so it can be set to true when restarting game
                this.gameObject.SetActive(false);

                //Create player object and call Increase function
                PlayerCharacter player = other.GetComponent<PlayerCharacter>();
                player.IncreaseHealth(3);

            }
        }
    }

    public void HealthReset()
    {
        soundPlayed = true;
        this.gameObject.SetActive(true);
    }
}