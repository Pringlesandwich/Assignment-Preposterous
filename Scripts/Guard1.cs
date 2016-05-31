using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Guard1 : MonoBehaviour {

	public Text guardTalker; //UI text

	int guardStage = 1;		// beer or no beer
	int guardTalk1 = 1; 	// talker case statement stage 1
	int guardTalk2 = 1;		// 2...

	//countdown
	float countDown = 1.0f;
	bool timer = false;

	public Rigidbody rb;


	// Use this for initialization
	void Start () {
	
		GameManagement.beer = false;

	}


	// Update is called once per frame
	void Update () 
	{

		if (GameManagement.beer == true) 
		{
			guardStage = 2;
		}


		if (timer) 
		{
			countDown -= Time.deltaTime; //timer fixed to delta time
		
			//when countdown 0
			if (countDown <= 0.0f) 
			{
				guardTalker.text = "";
				timer = false;		//turn function off
				countDown = 2.5f; 	//reset timer for next time
			}	
		}
	}


	//when player clicks on guard
	public void guardTalking ()
	{
		//initial stage
		if(guardStage == 1)
		{
			switch (guardTalk1)
			{
			case 1:
				guardTalker.text = "ERSTER WELTKRIEG WAR HART AUF MEINE KNOCHEN";
				timer = true;
				break;
			case 2:
				guardTalker.text = "EIN KLEINER BIER BITTE";
				timer = true;
				guardTalk1 = 0; //loops
				break;
			}
			//add to switch statement
			guardTalk1 ++;
		}
		
		//when player has chocolate
		if(guardStage == 2)
		{
			switch (guardTalk2)
			{
			case 1:
				guardTalker.text = "BIER! FüR MICH?";
				timer = true;
				break;
			case 2:
				guardTalker.text = "DANKE SCHOEN!";
				timer = true;
				//give and find ridgidbody
				gameObject.AddComponent<Rigidbody> ();  
			    rb = GetComponent<Rigidbody> ();  
				rb.AddForce ( - transform.forward * 200); //throws rb backwards
				guardStage ++; // unable to talk
				break;
			}
			//add to switch statement
			guardTalk2 ++;
		}
	}



}
