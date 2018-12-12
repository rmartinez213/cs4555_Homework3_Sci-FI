//Game Programming HW1 
//================================================================
// Name        : MouseLook.cs //Homework1
// Author      : Miguel Cayetano & Robert Martinez
// Description : Attached to Camera. Allows camera to look around.
//===============================================================

using UnityEngine;
using System.Collections;

// MouseLook rotates the transform based on the mouse delta.
// To make an FPS style character:
// - Create a capsule.
// - Add the MouseLook script to the capsule.
//   -> Set the mouse look to use MouseX. (You want to only turn character but not tilt it)
// - Add FPSInput script to the capsule
//   -> A CharacterController component will be automatically added.
//
// - Create a camera. Make the camera a child of the capsule. Position in the head and reset the rotation.
// - Add a MouseLook script to the camera.
//   -> Set the mouse look to use MouseY. (You want the camera to tilt up and down like a head. The character already turns.)

[AddComponentMenu("Control Script/Mouse Look")]
public class MouseLook : MonoBehaviour {
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 5.0f;
	public float sensitivityVert = 5.0f;
	
	public float minimumVert = -30.0f;
	public float maximumVert = 30.0f;
    public static bool isShutOff = true;

	private float _rotationX = 0;
	
	void Start() {
		// Make the rigid body not change rotation
		Rigidbody body = GetComponent<Rigidbody>();
        isShutOff = true;
		if (body != null)
			body.freezeRotation = true;
	}

	void Update() {
        if(isShutOff){
        	if (axes == RotationAxes.MouseX) {
        		transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        	}
        	else if (axes == RotationAxes.MouseY) {
        		_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        		_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
        		
        		transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
        	}
        	else {
        		//float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor;

        		_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        		_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                //What I added for Homework
        		float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        		float rotationY = transform.localEulerAngles.y + delta;

        		transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        	}
        }
    }

    public static void shutOffMouselook(){
        isShutOff = false;
    }
}