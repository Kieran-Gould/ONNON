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
	private Color muzzleFlashColour = new Color(1.0F, 0.376F, 0.0F);
	private Light muzzleFlash;

	void Start () { 
		muzzleFlash = gameObject.transform.Find ("Muzzle Flash").GetComponent<Light>();																				// Get the muzzle flash spotlight
	}

	void Update () {
		muzzleFlash.color -= muzzleFlashColour / 0.05F * Time.deltaTime;
		if (isFiring) {																												// If left mouse button is held down
			shotCounter -= Time.deltaTime;																							// Count down until next bullet can be fired
			if (shotCounter <= 0) {																									// If reload timer is zero
				shotCounter = timeBetweenShots;																						// Reset reload timer to delay specified
				BulletController newBullet = Instantiate (bullet, firePoint.position, firePoint.rotation) as BulletController;		// Create new bullet, using firePoint's position/rotation
				newBullet.speed = bulletSpeed; 																						// Apply speed specified
				muzzleFlash.color = muzzleFlashColour;
			}
		} 
		else {
			shotCounter = 0;																										// Set reload timer to zero
		}
	}
}
