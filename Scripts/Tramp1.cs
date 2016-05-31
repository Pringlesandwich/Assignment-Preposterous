using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tramp1 : MonoBehaviour {

	//text to canvas
	public Text tramp1Talker;
	int tramp1Text = 1;

	//countdown
	public float countDown = 2.0f;
	public bool timer = false;

	void Update ()
	{
		//when clicked on
		if (timer == true)
		{
			Debug.Log ("timer");
			//start timer
			countDown -= Time.deltaTime;
			//when countdown 0
			if (countDown <= 0.0f) {
				tramp1Talker.text = "";
				//turn function off
				timer = false;
			}
		}
	}

	//TRAMP SPEECH
	public void tramp1Talking()
	{
		Debug.Log ("timer");
		//start speech timer
		timer = true;
		//set timer
		countDown = 2.0f;
		//Text
		switch (tramp1Text)
		{
		case 1:
			tramp1Talker.text = "WATCH OUT FOR PIGEON SPIES!";
			break;
		case 2:
			tramp1Talker.text = "THEY'RE EVERYWHERE";
			break;
		case 3:
			tramp1Talker.text = "YOU WANNA KNOW HOW I GOT THESE SCARS??";
			break;
		case 4:
			tramp1Talker.text = "I LICKED THE HONEY OFF MY BUTTER KNIFE...";
			break;
		case 5:
			tramp1Talker.text = "GO CUT ME A SWITCH";
			break;
		case 6:
			tramp1Talker.text = "*MUMBLES...";
			//loops
			tramp1Text = 2;
			break;
		}
		//add to switch statement
		tramp1Text ++;
	}
}
