using UnityEngine;
using System.Collections;

public class walltriggerscript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.name == "arrow"){
			Destroy(collision.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
