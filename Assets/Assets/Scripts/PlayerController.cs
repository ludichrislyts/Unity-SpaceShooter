﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;	
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private static bool alive = true;
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource> ().Play ();

		}
	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		var player = GetComponent<Rigidbody> ();
			
		player.velocity = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed;
		player.position = new Vector3 (
			Mathf.Clamp (player.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (player.position.z, boundary.zMin, boundary.zMax)
		);

		player.rotation = Quaternion.Euler (0.0f, 0.0f, player.velocity.x * -tilt) ;
			
	}

	public static void kill()
	{
		alive = false;
	}

	public static bool isAlive()
	{
		return alive;
	}
}
