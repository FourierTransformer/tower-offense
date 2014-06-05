using UnityEngine;
using System.Collections;

public class flameRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
		// Slowly rotate the object around its X axis at 20 degree/second.
		//transform.Rotate(Vector3.right, 20 * Time.deltaTime);
		// ... at the same time as spinning it relative to the global 
		// Y axis at the same speed.
		transform.Rotate(Vector3.back, 108 * Time.deltaTime, Space.World);
	}
}
