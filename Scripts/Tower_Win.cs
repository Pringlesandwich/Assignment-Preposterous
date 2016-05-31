using UnityEngine;
using System.Collections;

public class Tower_Win : MonoBehaviour {

	//When player enters trigger radius
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			Application.LoadLevel("Credits_Scene");
		}
		
	}
}
