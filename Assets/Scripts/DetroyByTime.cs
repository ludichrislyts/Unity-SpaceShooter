using UnityEngine;
using System.Collections;

public class DetroyByTime : MonoBehaviour {

	public float lifetime;

	void Start()
	{
		Destroy (gameObject, lifetime);
	}
}
