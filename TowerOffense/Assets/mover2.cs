using UnityEngine;
using System.Collections;

public class mover2 : MonoBehaviour {

	public float speed = 8.0f;

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.name == "meleemonster" || collision.gameObject.name == "archer" ||
		    collision.gameObject.name == "grenadier" || collision.gameObject.name == "landminedropper" || 
		    collision.gameObject.name == "suicidebomber" || collision.gameObject.name == "wallhugger") {
			Destroy(gameObject);
		}
	}

	void Update(){
		rigidbody2D.AddForce (transform.up * speed);
	}

}
