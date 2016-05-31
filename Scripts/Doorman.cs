using UnityEngine;
using System.Collections;
//must have for Text edit
using UnityEngine.UI;

public class Doorman : MonoBehaviour {

	//Sound
	public AudioClip getLost;
	public AudioClip buzzOff;
	AudioSource doormanSound;

	//countdown
	float countDown = 1.0f;
	bool timer = false;

	//for looking at player
	bool lookAt = false;
	public Transform target;
	public Transform wall;

	// text in canvas
	public Text doorTalker;
	// talker case statement
	int doorTalk = 1;

	//TESTING
//	public Renderer rend;
//	public Color colour = Color.green;

	// Use this for initialization
	void Start () {
	// COLOUR CHANGE TEST
	//Vector3 def = new Vector3(0,1,0);
	//Renderer.material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
	//	rend = GetComponent<Renderer> ();
	//	rend.material.color.a = 0.5f;
	//	colour.a = 0.5f;

		//find the audiosource on doorman
		doormanSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		//timer called when object clicked on
		if (timer) 
		{
			//timer fixed to delta time
			countDown -= Time.deltaTime;
			lookAt = true;

			//when countdown 0
			if (countDown <= 0.0f) 
			{
				lookAt = false;
				doorTalker.text = "";
				//turn function off
				timer = false;
				//reset timer for next time
				countDown = 1.0f;
			}
		}

		//SMOOTH LOOK AT
		if (lookAt) 
		{
			//create a Vector 3 at the point between the player and NPC - maybe getting a vector3 magnitude?
			Vector3 relativePos = target.position - transform.position;
			//create a Quaternion with the LookRotation set between the current rotation and player (lock the Y but it doent work?)
			Quaternion rotation = Quaternion.LookRotation (relativePos, new Vector3(0,1,0));
			//rotation = lerp from (current, to player, over time)
			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime * 20);
			//transform.rotation = rotation
			//transform.rotation = Quaternion.Lerp(transform.rotation, playerPos, Time.deltaTime);
		} 
		else 
		{
			//find a way for NPC to lerp to default position
			//transform.rotation = Quaternion.identity;
		//	Quaternion rotaty = Quaternion.LookRotation (, Vector3.up);
			//rotate from current rotation, to player, over time, every frame

			//rotation = lerp ( current, to default, over time
			//transform.rotation = Quaternion.Lerp (transform.rotation, transform.rotation, Time.deltaTime * 20);
			transform.LookAt(wall);
		}
	}

	//when clicked on
	public void doorTalking()
	{
		//talking case statement
		switch (doorTalk)
		{
		case 1:

			doormanSound.PlayOneShot(getLost);
			doorTalker.text = "GET LOST WEAKLING";
			timer = true;

			break;
		
		case 2:

			doormanSound.PlayOneShot(buzzOff);
			doorTalker.text = "BUZZ OFF LOSER";
			timer = true;
			//reset conversation
			doorTalk = 0;
			break;

		}
		doorTalk ++;
	}
}
