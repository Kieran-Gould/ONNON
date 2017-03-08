using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour {

	public bool isFiring;																											// Is the bullet firing or not?
	public BulletController bullet;																									// Link the bullet firing script to this object
	public float bulletSpeed;																										// Define bullet speed
	public float timeBetweenShots;																									// Time delay between shots
	private float shotCounter;																										// Keep track of the last bullet fired
	public Transform firePoint;																										// Location where bullet should be spawned

	void Update () {
		if (isFiring) {																												// If left mouse button is held down
			shotCounter -= Time.deltaTime;																							// Count down until next bullet can be fired
			if (shotCounter <= 0) {																									// If reload timer is zero
				shotCounter = timeBetweenShots;																						// Reset reload timer to delay specified
				BulletController newBullet = Instantiate (bullet, firePoint.position, firePoint.rotation) as BulletController;		// Create new bullet, using firePoint's position/rotation
				newBullet.speed = bulletSpeed; 																						// Apply speed specified
			}
		} 
		else {
			shotCounter = 0;																										// Set reload timer to zero
		}
	}
}
