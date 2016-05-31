using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {
	
	//set gate open angle
	float gateOpen = -90.0f;
	//set open state to false
	bool open = false;

	// Update is called once per frame
	void Update () {
		
		/*
		//FOR GATE TESTING
		if (Input.GetKeyDown ("g")) 
		{
			open = true;
		}
		*/
		
		//This opens door, it has to be in an update function for the smooth open
		if (open) 
		{
			//create a quaternion that has a transform rotation with a 90 degree turn in y
			Quaternion openRotation = Quaternion.Euler (0, gateOpen, 0);
			//local rotate because rotate around hinge, lerp from current to open angle
			transform.localRotation = Quaternion.Lerp (transform.localRotation, openRotation, Time.deltaTime * 3.0f);
		}
	}
	
	//called when password is correct
	public void keypadOpen()
	{
		open = true;
	}	
}