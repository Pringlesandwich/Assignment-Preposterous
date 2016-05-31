using UnityEngine;
using System.Collections;
//must have for Text edit
using UnityEngine.UI;


public class ChocolateSeller : MonoBehaviour {

	//coundown for shout !!!TESTING
	float countDown = 2.0f;
	bool timer = false;


	public Transform target;
	bool lookAt = false;
	
	// text in canvas
	public Text sellTalker;
	//stage of sec, will change when chocolate is bought
	public int sellStage = 1;
	// talker case statement stage 1
	public int sellTalk1 = 1;
	// 2...
	public int sellTalk2 = 1;
	

	// Use this for initialization
	void Start () {
	
		GameManagement.coin = false;

	}
	
	// Update is called once per frame
	void Update () {
	

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
		
		if (GameManagement.chocolate == true) 
		{
			sellStage = 2;
		}
	
		//TESTING FOR TIMER

		if (timer) 
		{
			//2 seconds till countdown = 0
			countDown -= Time.deltaTime;
			lookAt = true;
			//when countdown 0
			if (countDown <= 0.0f) {
				// Debug.Log ("Timer is 0"); 
				lookAt = false;
				sellTalker.text = "";
				//turn function off
				timer = false;
				//reset timer for next time
				countDown = 2.0f;
			}
		}
	}


	public void sellTalking ()
	{
		
		if(sellStage == 1)
		{
			switch (sellTalk1)
			{
			case 1:
				sellTalker.text = "BUY SOME CHOCOLATE?";
				timer = true;
				break;
			case 2:
				sellTalker.text = "IS GOOD CHOCOLATE, ONE COINS ONLY";
				timer = true;
				break;
			case 3:
				sellTalker.text = "PLEASE FOR CHOCOLATE";
				timer = true;
				//loops
				sellTalk1 = 0;
				break;
			}
			//add to switch statement
			sellTalk1 ++;
			
		}
		
		if(sellStage == 2)
		{
			switch (sellTalk2)
			{
			case 1:
				sellTalker.text = "THANKYOU FOR BUY CHOCOLATE";
				timer = true;
				break;
			case 2:
				sellTalker.text = "YOU DID GOOD FOR CHOCOLATE";
				timer = true;
				break;
				//this makes it so it doesn't loop
			default:
				sellTalker.text = "NO MORE CHOCOLATE...";
				timer = true;
				break;
			}
			//add to switch statement
			sellTalk2 ++;
			
		}
		
	}

	//Whent player click chocolate with no money
	public void sellShouting ()
	{
		timer = true;
		sellTalker.text = "MONEY FOR CHOCOLATE!";
		
	}


	//When player enters trigger radius
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.name == "Player")
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
			sellTalker.text = "";
		}
		
	}

}
