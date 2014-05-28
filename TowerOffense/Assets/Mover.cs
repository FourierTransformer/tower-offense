using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed = 3.0f;
	void Start ()
	{
		rigidbody.velocity = transform.up * speed;

	}
}
