using UnityEngine;
using System.Collections;

public class mover2 : MonoBehaviour {

	public float speed = 8.0f;

	void Update(){
		rigidbody2D.AddForce (transform.up * speed);
	}

}
