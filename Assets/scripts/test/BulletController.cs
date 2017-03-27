using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;																	// Speed of the projectile			
	private float lifetime = 5;															// Bullet lifetime

	void Start () {
		Destroy(gameObject, lifetime);													// Destroy gameObject after lifetime
	}

	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime); 					// Translates the bullet forward, based on it's speed, using delta time to ensure it doesn't jitter
	}

	void OnCollisionEnter(Collision collisionInfo) {									// If collide with any object
		if (collisionInfo.gameObject.tag == "Enemy") {
			collisionInfo.gameObject.GetComponent<enemyController>().hurtEnemy(20);		// Hurt enemy for 20 damage
		}
		Destroy(gameObject);															// Destroy this object
	}
}
