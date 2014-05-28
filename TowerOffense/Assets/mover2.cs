using UnityEngine;
using System.Collections;

public class mover2 : MonoBehaviour {

	public float speed = 3.0f;
	// Update is called once per frame
	void Start () {
		rigidbody2D.velocity = transform.up * speed;
	}
}
