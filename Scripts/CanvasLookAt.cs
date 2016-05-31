using UnityEngine;
using System.Collections;

public class CanvasLookAt : MonoBehaviour {

	public Transform player; //player controller

	// Update is called once per frame
	void Update () 
	{

		transform.LookAt (player); //canvas faces player
		transform.Rotate (Vector3.up * 180); // spin canvas to get to correct face

	}
}
