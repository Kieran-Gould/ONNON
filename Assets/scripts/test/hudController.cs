using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hudController : MonoBehaviour {

	public Material[] materials;								// List of mateirals to cycle through

	public int health1;											// Health for player 1
	public int health2;											// Health for player 2

	private GameObject heart_1A;
	private GameObject heart_1B;
	private GameObject heart_1C;
	private GameObject heart_1D;
	private GameObject heart_1E;

	private Renderer heart1A_Rend;
	private Renderer heart1B_Rend;
	private Renderer heart1C_Rend;
	private Renderer heart1D_Rend;
	private Renderer heart1E_Rend;

	void Start () {
		heart_1A = GameObject.Find("heart_1A");					// Get all objects
		heart_1B = GameObject.Find("heart_1B");
		heart_1C = GameObject.Find("heart_1C");
		heart_1D = GameObject.Find("heart_1D");
		heart_1E = GameObject.Find("heart_1E");

		heart1A_Rend = heart_1A.GetComponent<Renderer> (); 		// Get their renderer so we can modify their textures
		heart1B_Rend = heart_1B.GetComponent<Renderer> (); 
		heart1C_Rend = heart_1C.GetComponent<Renderer> (); 
		heart1D_Rend = heart_1D.GetComponent<Renderer> (); 
		heart1E_Rend = heart_1E.GetComponent<Renderer> (); 
	}

	void Update () {
			
		if (health1 == 5) {										// Set HUD materials based on player health
			heart1A_Rend.material = materials [0];
			heart1B_Rend.material = materials [0];
			heart1C_Rend.material = materials [0];
			heart1D_Rend.material = materials [0];
			heart1E_Rend.material = materials [0];
		}
		if (health1 == 4) {
			heart1A_Rend.material = materials [0];
			heart1B_Rend.material = materials [0];
			heart1C_Rend.material = materials [0];
			heart1D_Rend.material = materials [0];
			heart1E_Rend.material = materials [1];
		}
		if (health1 == 3) {
			heart1A_Rend.material = materials [0];
			heart1B_Rend.material = materials [0];
			heart1C_Rend.material = materials [0];
			heart1D_Rend.material = materials [1];
			heart1E_Rend.material = materials [1];
		}
		if (health1 == 2) {
			heart1A_Rend.material = materials [0];
			heart1B_Rend.material = materials [0];
			heart1C_Rend.material = materials [1];
			heart1D_Rend.material = materials [1];
			heart1E_Rend.material = materials [1];
		}
		if (health1 == 1) {
			heart1A_Rend.material = materials [0];
			heart1B_Rend.material = materials [1];
			heart1C_Rend.material = materials [1];
			heart1D_Rend.material = materials [1];
			heart1E_Rend.material = materials [1];
		}
		if (health1 == 0) {
			heart1A_Rend.material = materials [1];
			heart1B_Rend.material = materials [1];
			heart1C_Rend.material = materials [1];
			heart1D_Rend.material = materials [1];
			heart1E_Rend.material = materials [1];
		}


	}
}
