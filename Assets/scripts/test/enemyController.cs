using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

	private Rigidbody myRB;
	public float movementSpeed;
	public PlayerController thePlayer;
	public int health = 100;
	private int currentHealth;
	public GameObject sparks;
	private GameObject sparksObject;

	void Start () {
		myRB = GetComponent<Rigidbody>();							// Get player collision
		thePlayer = FindObjectOfType<PlayerController>();			// Get player controller
		currentHealth = health;
	}

	void FixedUpdate () {
		myRB.velocity = (transform.forward * movementSpeed);
	}

	void Update () {
		if (currentHealth <= 0) {
			GameObject sparksObject = Instantiate (sparks, transform.position, new Quaternion(0,0,0,0)) as GameObject;
			Destroy (gameObject);
		}

		transform.LookAt (thePlayer.transform.position);			// Turn to look at player
	}

	public void hurtEnemy(int damage) {
		currentHealth -= damage;
	}
}
