using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraKeypad : MonoBehaviour {

	//SCRIPTS
	public GameManagement release; //talk to Manager script
	public Gate passCorrect; 	   //talk to gate script

	public string keyIn; 	//string to store button presses
	public Text display; 	// Text on canvas
	
	//FOR RANDOM NUMBER GEN
	int n;
	string password;
	
	public Text codePad; 	//to send code to notepad

	// Use this for initialization
	void Start () 
	{
		//generate random int between.... and convert to string
		n = Random.Range(1000,9999);
		// print (n);
		password = n.ToString();
		codePad.text = password;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		display.text = keyIn;  //Text appear on keypad

		//if keyIn is larger than 3 character
		if (keyIn.Length>3)
		{
			//if same as password open door
			if(keyIn == password)
			{
				keyIn = ""; //reset display

				//open door and release camera
				passCorrect.keypadOpen();
				release.keypadActive ();
				//Debug.Log("open door");
			}
			else
			{
				keyIn = ""; //else reset keyIn
			}
		}
	}

	//THIS NEED TIDYING, ADD A STRING OR IN AS PARAMETER AND HAVE ONLY ONE

	//Button inputs add a corisponding number to string
	public void but1(){
		keyIn = keyIn + "1";
		Debug.Log (keyIn);
	}
	public void but2(){
		keyIn = keyIn + "2";
		Debug.Log (keyIn);
	}
	public void but3(){
		keyIn = keyIn + "3";
		Debug.Log (keyIn);
	}
	public void but4(){
		keyIn = keyIn + "4";
		Debug.Log (keyIn);
	}
	public void but5(){
		keyIn = keyIn + "5";
		Debug.Log (keyIn);
	}
	public void but6(){
		keyIn = keyIn + "6";
		Debug.Log (keyIn);
	}
	public void but7(){
		keyIn = keyIn + "7";
		Debug.Log (keyIn);
	}
	public void but8(){
		keyIn = keyIn + "8";
		Debug.Log (keyIn);
	}
	public void but9(){
		keyIn = keyIn + "9";
		Debug.Log (keyIn);
	}
	public void but0(){
		keyIn = keyIn + "0";
		Debug.Log (keyIn);
	}
	public void butOut(){

		release.keypadActive ();

	}

}
