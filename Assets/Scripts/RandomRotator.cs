using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble;
	// Use this for initialization
	void Start ()
	{
		var asteroid = GetComponent<Rigidbody> ();
		asteroid.angularVelocity = Random.insideUnitSphere * tumble;
	}

}
