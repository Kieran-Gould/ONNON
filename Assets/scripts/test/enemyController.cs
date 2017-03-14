using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

	private Rigidbody myRB;
	public float movementSpeed;
	public PlayerController thePlayer;
	public int health;
	private int currentHealth;

	void Start () {
		myRB = GetComponent<Rigidbody>();					// Get player collision
		thePlayer = FindObjectOfType<PlayerController>();	// Get player controller
	}

	void FixedUpdate () {
		myRB.velocity = (transform.forward * movementSpeed);
	}

	public void hurtEnemy(int damage) {
		currentHealth -= damage;
	}

	void Update () {
		if (currentHealth <= 0) {
			Destroy (gameObject);
		}

		transform.LookAt (thePlayer.transform.position);	// Turn to look at player
	}
}
