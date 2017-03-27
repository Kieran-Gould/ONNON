using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed; 																			// Player max speed
	private Rigidbody myRigidBody; 																		// The player's physical body
	private Vector3 moveInput; 																			// Current input of horizontal and vertical controller/keyboard axis
	private Vector3 moveVelocity; 																		// How fast the player is currently moving
	private Camera mainCamera; 																			// Player camera
	private GameObject cameraRig;																		// The camera rig which moves along with the player
	public gunController gun;																			// Links the player to the gun controller script
	public int playerHealth;																			// The player's health
	private float invunTime = 3;																		// Time the player is invincible after being hit
	private float invunCounter;																			// The timer which counts down after the player is hit
	public int playerNumber;																			// Player ID number
	public GameObject HUD_Object;																		// Reference to the HUD GameObject

	void Start () {
		myRigidBody = GetComponent<Rigidbody>(); 														// Get player body
		mainCamera = FindObjectOfType<Camera>(); 														// Get player camera

		if (playerNumber == 1) {
			cameraRig = GameObject.Find("Camera Rig 1"); 												// Find camera rig for
		}
		if (playerNumber == 2) {
			cameraRig = GameObject.Find("Camera Rig 2");
		}
	}

	void OnCollisionEnter(Collision other) {															// If collide with enemy
		if (other.gameObject.tag == "Enemy") {
			if (invunCounter <= 0) {																	// If the player is not invincible right now
				playerHealth -= 1;																		// Reduce their health by one
				invunCounter = invunTime;																// Reset invun counter to variable set
			}
		}
	}

	void Update () {
		invunCounter -= Time.deltaTime;																	// Deincriment the invun timer using delta

		if (playerHealth < 1) {																			// If the player is dead and have less than one life, aka zero
			Debug.Log ("GAME OVER");
		}

		moveInput = new Vector3 (Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); 	// Get both axis from keyboard/controller
		moveVelocity = moveInput * moveSpeed; 															// Velocity is the maximum speed of player movement, times by the input which can range from zero to one
	
		Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition); 								// Cast a ray from the camera to where the mouse is point over onscreen
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero); 										// Create a plane for the ray to intersect
		float rayLength; 																				// Store the ray data in a float

		if (groundPlane.Raycast(cameraRay, out rayLength)) { 											// If our ray is hitting something
			Vector3 pointToLook = cameraRay.GetPoint(rayLength); 										// Store where the ray hits in a Vector3
			transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z)); 			// Look at raycast location
		}
		//cameraRig.transform.position = myRigidBody.transform.position;									// Move the camera rig to where the player is positioned

		if (Input.GetMouseButtonDown (0)) {																// If the left mouse button (0) is held down
			gun.isFiring = true;																		// Set isFiring to True

		}
		if (Input.GetMouseButtonUp (0)) {																// If the left mouse button (0) is released
			gun.isFiring = false;																		// Set isFiring to False
		}

		if (playerNumber == 1) {
			HUD_Object.GetComponent<hudController>().health1 = playerHealth;					// Get reference to the int health variable on the HUD, and assign it to HUD_Ref
		}
		if (playerNumber == 2) {
			HUD_Object.GetComponent<hudController>().health2 = playerHealth;
		}																		
	}

	void FixedUpdate () {
		myRigidBody.velocity = moveVelocity; 															// Update player movement on a regular interval 
	}
}
