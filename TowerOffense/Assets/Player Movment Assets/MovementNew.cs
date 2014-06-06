using UnityEngine;
using System.Collections;

public class MovementNew : MonoBehaviour {

	public float speed = 5.0f;
	
	// Update is called once per frame
	void Update () {

		float x = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		float y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.Translate (x, y, 0);
	}
}
