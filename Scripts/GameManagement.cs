using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {

	// NOTE: CHANGE THIS TO A CLASS, USING IT AS AN INVENTORY
	//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	//E.G:
	//public class inventory {

	//public static bool chocolate;
	//public static bool coin;

	//public inventory(bool chocolate, bool coin)
	//{
	//chocolate = choc;
	//coin = coin;
	//}
	//}

	// public inventory myInv = new inventory(false, false);


	//Pause menu variables
	public GameObject OptionMenu;
	public GameObject PauseMenu;
	//check is game is paused
	bool paused;
	//option button clicked bool
	bool active;
	//pausable if in main camera only
	bool pausable;
	//check player isn't in option menu
	bool options;
	//for turning crosshair on and off
	public Text crosshair;
	//graphics raycaster to toggle on/off 
	public GraphicRaycaster gr;
	//gr for the keypad
	public GraphicRaycaster keyPadgr;

	public static bool chocolate; 	//chocolate inv
	public static bool coin; 		//coin inv
	public static bool beer; 		//Beer inv
	
	//cameras in scene
	public Camera playerCam;
	public Camera keypadCam;
	
	//SCRIPTS
	public FirstPersonController camSwitch;
	public InteractionRaycast intOff;

	//RESET MOUSE ON EXIT
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 cursorReset = Vector2.zero;

	// Use this for initialization
	void Start () {
		//turn cursor off
		UnityEngine.Cursor.visible = false;
		//turn off objects held in script
		chocolate = false;
		coin = false;
		beer = false;

		//Camera states
		playerCam.enabled = true;
		keypadCam.enabled = false;

		active = false;		//pause menu off
		options = false;	//options off
		pausable = true;	//game starts pausable
		paused = false;		//is game paused?

		//Tower win collider

	}
	
	// Update is called once per frame
	void Update () {
	
		//pause game, open PauseMenu
		if (Input.GetKeyDown ("escape") && pausable && !paused) 
		{
			pauseGame ();
		} 
		//if escape is presses in pause menu then exit
		else if (Input.GetKeyDown ("escape") && paused && !options) 
		{
			unpauseGame ();
		}
		//if escape is pressed in options menu then goto pause menu
		else if (Input.GetKeyDown ("escape") && options) 
		{
			optionMenu(active);
		}
	}

	//INVENTORY
	//interacted with chocolate
	public void chocPickup ()
	{
		chocolate = true;
	}
	//interacted with coin
	public void coinPickup ()
	{
		coin = true;
	}
	//interacted with beer
	public void beerPickup ()
	{
		beer = true;
	}

	//switch from player to keypad camera
	public void keypadActive ()
	{
		//Debug.Log ("switch");
		//switch cameras
		playerCam.enabled = !playerCam.enabled;
		keypadCam.enabled = !keypadCam.enabled;
		//call freeze script in player and camera
		camSwitch.freezePlayer ();
		intOff.freezeCamera ();
		//turn cursor on/off
		UnityEngine.Cursor.visible = !UnityEngine.Cursor.visible;
		pausable = !pausable;
		keyPadgr.enabled = !keyPadgr.enabled;//ability to click buttons

		//move cursor away from close button
		Cursor.SetCursor(null, cursorReset, cursorMode);


	}

	//PAUSE FUNCTIONS HERE
	//fall function with parameter active
	public void optionMenu(bool active)
	{
		if (active)
		{
			//options menu condition linked to boolean
			OptionMenu.gameObject.SetActive (active);
			PauseMenu.gameObject.SetActive (false);
			options = true;
		} 
		else 
		{
			OptionMenu.gameObject.SetActive (active);
			PauseMenu.gameObject.SetActive (true);
			options = false;
		}	
	}


	public void pauseGame ()
	{
		//when esc is pressed
		Time.timeScale = 0;
		UnityEngine.Cursor.visible = !UnityEngine.Cursor.visible ;
		//turn crooshair off
		crosshair.text = "";
		PauseMenu.gameObject.SetActive(true);
		paused = true;
		//GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>;
		//toggle Graphics Raycast on so can push buttons
		gr.enabled = !gr.enabled;
		camSwitch.freezePlayer ();
		intOff.freezeCamera ();
	}


	public void unpauseGame ()
	{
		Debug.Log ("unpaused");
		Time.timeScale = 1;
		UnityEngine.Cursor.visible = !UnityEngine.Cursor.visible ;
		crosshair.text = ".";
		PauseMenu.gameObject.SetActive(false);
		paused = false;
		gr.enabled = !gr.enabled;
		camSwitch.freezePlayer ();
		intOff.freezeCamera ();
	}

	//Quit game
	public void quitGame()
	{
		//DOESN'T WORK IN EDITOR
		Application.Quit ();
	}
}
