using UnityEngine;
using System.Collections;

public class mover2 : MonoBehaviour {

	public float speed = 8.0f;
	
	private enemyhealth enemyHealth;

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.name == "meleemonster" || collision.gameObject.name == "archer" ||
		    collision.gameObject.name == "grenadier" || collision.gameObject.name == "landminedropper" || 
		    collision.gameObject.name == "suicidebomber" || collision.gameObject.name == "wallhugger") {
			enemyHealth = collision.gameObject.GetComponent<enemyhealth>();
			float damage = 10f;
			enemyHealth.TakeDamage(damage);
			Destroy(gameObject);
		}
		
		if(collision.gameObject.name == "Collisions_Object" || collision.gameObject.name == "Collisions_Object2" ||
		   collision.gameObject.name == "Collisions_Object3" || collision.gameObject.name == "Collisions_Object4" ||
		   collision.gameObject.name == "Collisions_Object5" || collision.gameObject.name == "Collisions_Object6" ||
		   collision.gameObject.name == "Collisions_Object7" || collision.gameObject.name == "Collisions_Object8" ||
		   collision.gameObject.name == "Collisions_Object9" || collision.gameObject.name == "Collisions_Object10" ||
		   collision.gameObject.name == "Collisions_Object11" || collision.gameObject.name == "Collisions_Object12" ||
		   collision.gameObject.name == "Collisions_Object13" || collision.gameObject.name == "Collisions_Object14" ||
		   collision.gameObject.name == "Collisions_Object15" || collision.gameObject.name == "Collisions_Object16" ||
		   collision.gameObject.name == "Collisions_Object17" || collision.gameObject.name == "Collisions_Object18" ||
		   collision.gameObject.name == "Collisions_Object19" || collision.gameObject.name == "Collisions_Object20" ||
		   collision.gameObject.name == "Collisions_Object21" || collision.gameObject.name == "Collisions_Object22" ||
		   collision.gameObject.name == "Collisions_Object23" || collision.gameObject.name == "Collisions_Object24" ||
		   collision.gameObject.name == "Collisions_Object25" || collision.gameObject.name == "Collisions_Object26" ||
		   collision.gameObject.name == "Collisions_Object27" || collision.gameObject.name == "Collisions_Object28"){
			Destroy(gameObject);
		}
	}

	void Update(){
		rigidbody2D.AddForce (transform.up * speed);
	}

}
