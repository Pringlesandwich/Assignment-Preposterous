using UnityEngine;
using System.Collections;
//API allows Text edit
using UnityEngine.UI;

public class Secretary : MonoBehaviour {

	//Look at variable
	public Transform target;
	bool lookAt = false;
	bool looker = true;

	// text in canvas
	public Text secTalker;
	//stage of sec, will change when chocolate is bought
	int secStage = 1;
	// talker case statement stage 1
	int secTalk1 = 1;
	// 2...
	int secTalk2 = 1;

	public Rigidbody secRB;		//for fainting
	public GameObject doorMan;	//doorman delete

	// Use this for initialization
	void Start () {

		//find variable from gamemanagement script, this is used for conversation states
		GameManagement.chocolate = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		//LOOK AT PLAYER
		if (lookAt) {
			//SMOOTH LOOK AT
			//create a Vector 3 at the point between the player and NPC
			Vector3 relativePos = target.position - transform.position;
			//create a Quaternion with the look at rotation eqaul to the position of the player
			Quaternion rotation = Quaternion.LookRotation (relativePos, Vector3.up);
			//rotate from current rotation, to player, over time, every frame
			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime * 20);
			//transform.rotation = rotation
			//transform.rotation = Quaternion.Lerp(transform.rotation, playerPos, Time.deltaTime);
		}

		//when chocolate is bought
		if (GameManagement.chocolate == true) 
		{
			secStage = 2;
		}
	}
	
	//when player clicks on secretary
	public void secTalking ()
	{
		//initial stage
		if(secStage == 1)
		{
			switch (secTalk1)
			{
			case 1:
				secTalker.text = "HELLO, WELCOME TO METIER TOWERS";
				break;
			case 2:
				secTalker.text = "IS IT EASTER YET?";
				break;
			case 3:
				secTalker.text = "I'M SO HUNGRY...";
				//loops
				secTalk1 = 0;
				break;
			}
		//add to switch statement
		secTalk1 ++;
		}

		//when player has chocolate
		if(secStage == 2)
		{
			switch (secTalk2)
			{
			case 1:
				secTalker.text = "ARE THOSE CHOCOLATES FOR ME!?";
				break;
			case 2:
				secTalker.text = "OH MY! THANK YOU SO MUCH!";
				break;
				//this makes it so it doesn't loop
			default:
				looker = false;
				secTalker.text = "NOM NOM...";
				gameObject.AddComponent<Rigidbody> ();  
				secRB = GetComponent<Rigidbody> ();  
				secRB.AddForce ( - transform.forward * 200); //throws rb backwards
				doorMan.transform.position = new Vector3 (1000, 1000, 1000);

				break;
			}
			//add to switch statement
			secTalk2 ++;
		}
	}

	//When player enters trigger radius
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.name == "Player" && looker)
		{
			lookAt = true;
		}

	}
	//When Player leaves trigger radius
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.name == "Player")
		{
			lookAt = false;
			secTalker.text = "";
		}
	
	}
}
