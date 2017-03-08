using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;															// Speed of the projectile													

	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime); 			// Translates the bullet forward, based on it's speed, using delta time to ensure it doesn't jitter
	}

	void OnCollisionEnter(Collision collisionInfo) {							// If collide with any object
		Destroy(gameObject);													// Destroy this object
	}
}
