using UnityEngine;
using System.Collections;

public class Title_Script : MonoBehaviour {

	//THIS SCRIPT IS FOR THE TITLE MENU ONLY

	//menu screens
	public GameObject OptionMenu;
	public GameObject MainMenu;
	//option button clicked bool
	public bool active;
	
	// Use this for initialization
	void Start ()
	{
		UnityEngine.Cursor.visible = true;
		active = false;
	}

	//same as pause script so dont use static variables unless resetting them
	public void optionMenu(bool active)
	{
		if (active)
		{
			OptionMenu.gameObject.SetActive (active);
			MainMenu.gameObject.SetActive (false);
		} 
		else 
		{
			OptionMenu.gameObject.SetActive (active);
			MainMenu.gameObject.SetActive (true);		
		}

	}

	//button press start
	public void startGame()
	{
		//Open first scene
		Application.LoadLevel("Level_1");
	}

	//button press quit
	public void quitGame()
	{
		//Quit game
		//DOESN'T WORK IN EDITOR
		Application.Quit ();
	}

}
