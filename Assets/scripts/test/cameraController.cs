using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	public bool isMultiplayer;
	private GameObject player1;
	private GameObject player2;
	private GameObject HUD;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("Player1");							// Get player objects
		if (isMultiplayer == true) {
			player2 = GameObject.Find("Player2");
		}
		HUD = GameObject.Find ("Cube_010");
	}
	
	// Update is called once per frame
	void Update () {
		if (isMultiplayer == false) {
			transform.position = ((player1.transform.position + HUD.transform.position) / 3.0f);
		}
		if (isMultiplayer == true) {
			transform.position = (((player2.transform.position + player1.transform.position + HUD.transform.position) / 3.0f));		// Position camera between Player 1, Player 2, and the HUD
		}
	}
}
