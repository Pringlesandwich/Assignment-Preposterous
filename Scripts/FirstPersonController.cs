using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	//stables
	float mouseSensitivity = 5.0f;
	float moveSpeed = 5.0f;
	float jumpSpeed = 5.0f;
	float verticalVelocity = 0;

	//mouse look 
	float verticalRotation = 0f;
	float upDownRange = 60.0f;

	public bool controllable = true;

	//other and testing

	// public GameObject FPCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//when player not frozen
		if (controllable) {

			//THIS CHARACTER AND CAMERA CONTROLLER I GOT FROM QUILL18CREATES

			//Get players character controller (unity object)
			CharacterController cc = GetComponent<CharacterController> ();

			// CAMERA ROTATION
			//turn mouse movement into camera yaw
			float cameraYaw = Input.GetAxis ("Mouse X") * mouseSensitivity;
			transform.Rotate (0, cameraYaw, 0);

			// Turn mouse movement into variable
			verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
			//stop the camera moving more than 60 dgrees up or down
			verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
			//have camera pitch rotate
			Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);



			// PLAYER MOVEMENT
			//Turn input into variable
			float forwardSpeed = Input.GetAxis ("Vertical") * moveSpeed;
			float sideSpeed = Input.GetAxis ("Horizontal") * moveSpeed;
			//gravity effect player at this speed
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
			//if grounded then jump
			if (cc.isGrounded && Input.GetButtonDown ("Jump")) {
				verticalVelocity = jumpSpeed;
			}

			//Turn variable into Vector3 Movement
			Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);
			//change world movement to local movement
			speed = transform.rotation * speed;

			// helps lock to delta not framerate
			cc.Move (speed * Time.deltaTime);

		}

		//I used this code for the player controller
		// https://unity3d.com/learn/tutorials/modules/beginner/physics/raycasting
		
	}

	//called on pause etc.
	public void freezePlayer()
	{
		//bool freezes player
		controllable = !controllable;
	}
}
