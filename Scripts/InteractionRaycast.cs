using UnityEngine;
using System.Collections;

public class InteractionRaycast : MonoBehaviour {

	//Raycast lenght
	float interactionLength = 3.5f;

	//SCRIPTS
	public Secretary secInteract;
	public ChocolateSeller sellInteract;
	public GameManagement objectInteract;
	public Doorman doorInteract;
	public Tramp1 tramp1Interact;
	public Guard1 guardInteract;
	
	//turnoff interaction
	bool camControllable = true;

	// Use this for initialization
	void Start () {
	
		GameManagement.coin = false;
	}
	
	// Update is called once per frame
	void Update () {

		//if player can use camera
		if (camControllable)
		{
			//INTERACTION RAY
			//Ray store information
			RaycastHit hit;
			//Vector3 is always forward from camera
			Vector3 fwd = transform.TransformDirection (Vector3.forward);
			//Create ray, center of camera, fire forward
			Ray interactionRay = new Ray (transform.position, fwd);
			//test ray
			//	Debug.DrawRay (transform.position, fwd * 500);


			//If player clicks
			if (Input.GetButtonDown ("Fire1")) {
				//fire ray, stor info to hit, at this distance
				if (Physics.Raycast (interactionRay, out hit, interactionLength)) {

					//OBJECT INTERACTIONS

					//if ray hits this tag
					if (hit.collider.tag == "Chocolate") 
					{
						if (GameManagement.coin == true) {
							print ("Chocolate!");
							//gamemanager inventory
							objectInteract.chocPickup ();
							//destroy chocolate
							Destroy (hit.collider.gameObject);
						}
						if (GameManagement.coin == false) {
							sellInteract.sellShouting ();  
						}
					}
					if (hit.collider.tag == "Coin") {
						print ("Coin!");
						GameManagement.coin = true;
						//game manager inventory
						objectInteract.coinPickup ();
						//destory coin
						Destroy (hit.collider.gameObject);
					}
					if (hit.collider.tag == "Beer") {
						print ("Beer!");
						GameManagement.beer = true;
						//game manager inventory
						objectInteract.beerPickup ();
						//destory coin
						Destroy (hit.collider.gameObject);
					}
					if (hit.collider.CompareTag ("Secretary")) 
					{
						secInteract.secTalking ();  
					}
					if (hit.collider.CompareTag ("Seller")) 
					{
						sellInteract.sellTalking ();  
					}
					if (hit.collider.CompareTag ("Doorman")) 
					{
						doorInteract.doorTalking ();  
					}
					if (hit.collider.CompareTag ("Guard")) 
					{
						guardInteract.guardTalking ();
					}
					if (hit.collider.CompareTag ("Tramp1")) 
					{
						tramp1Interact.tramp1Talking ();  
					}
					if (hit.collider.CompareTag ("Keypad")) 
					{
						objectInteract.keypadActive ();  
					}
					//end level 
					if (hit.collider.CompareTag ("Basement")) 
					{
						Application.LoadLevel("Credits_Scene");
					}
				}
			}
		}
	}
	//freeze camera funtion
	public void freezeCamera ()
	{
		camControllable = !camControllable;
	}
}
