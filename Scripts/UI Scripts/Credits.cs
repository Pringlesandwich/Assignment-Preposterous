using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Credits : MonoBehaviour {

	//countodow before scroll
	float countDown = 3.0f;
	bool scroll = false;

	//detect end of audio
	public AudioSource credits;

	// Use this for initialization
	void Start () {
		//find audio
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//3 seconds
		countDown -= Time.deltaTime;
			
		//when countdown 0.....
		if (countDown <= 0.0f) 
		{
			scroll = true;
		}
		//....start credits
		if (scroll) 
		{
			transform.Translate (Vector3.up * Time.deltaTime * 35.0f);
		}
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}

		//when audio stops playing
		if (!credits.isPlaying) 
		{
			Application.LoadLevel("Title_Scene");
		}
	}
}
