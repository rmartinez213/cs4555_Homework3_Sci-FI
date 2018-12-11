//Game Programming HW1 
//==========================================================================================
// Name        : WeaponToggleScript.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Attached to WeaponToggle object. Allows guns to be toggled with right click
//==========================================================================================

using UnityEngine;
using UnityEngine.UI;

public class WeaponToggleScript : MonoBehaviour {

	public static int currentWeapon = 0;

    //Gun RawImage
    [SerializeField] private RawImage heavyGunImage; //rawImage
    [SerializeField] private RawImage rifleGunImage; //rawImage

    //Sound Source Code
    [SerializeField] private AudioSource soundSource; //player object
    [SerializeField] private AudioClip switchWeaponSound; //audio clip


    void Start () {
		selectWeapon();
	}

	void Update(){

		if (Input.GetMouseButtonDown(1)){
            currentWeapon++;

            //Weapon switch interval can only be 0 or 1 therefore if currentWeapon > 1 then switch to 0
            if (currentWeapon > 1)
                currentWeapon = 0;

            selectWeapon();
        }
	}

	void selectWeapon(){

		//Used to incrememnt weapon value (for switching)
		int i = 0;

		foreach(Transform weapon in transform){

			if (i == currentWeapon){
                weapon.gameObject.SetActive(true);
                rifleGunImage.gameObject.SetActive(true);
                heavyGunImage.gameObject.SetActive(false);
                soundSource.PlayOneShot(switchWeaponSound);
            }
            else{
                weapon.gameObject.SetActive(false);
                heavyGunImage.gameObject.SetActive(true);
                rifleGunImage.gameObject.SetActive(false);
            }

            i++;
		}
	}
}
