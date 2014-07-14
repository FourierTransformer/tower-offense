using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour {

	public GameObject shot;
	public float damage = 15f;

	private Animator animator;
	private List<GameObject> nearEnemy = new List<GameObject>();

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D collision){
			if (collision.gameObject.name == "meleemonster" || collision.gameObject.name == "archer" ||
		    collision.gameObject.name == "grenadier" || collision.gameObject.name == "landminedropper" || 
		    collision.gameObject.name == "suicidebomber" || collision.gameObject.name == "wallhugger") {
				nearEnemy.Add(collision.gameObject);
			}
		}
		
		void OnTriggerExit2D(Collider2D collision){
			if (collision.gameObject.name == "meleemonster" || collision.gameObject.name == "archer" ||
		    collision.gameObject.name == "grenadier" || collision.gameObject.name == "landminedropper" || 
		    collision.gameObject.name == "suicidebomber" || collision.gameObject.name == "wallhugger"){
				nearEnemy.Remove(collision.gameObject);
			}
		}	
		

	// Update is called once per frame
	void Update () {
	
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		if (vertical > 0)
		{
			animator.SetInteger("Direction", 2);
			animator.SetFloat("Change", 1.0f);
			if(Input.GetMouseButtonDown(0)){
				Melee();
				animator.SetInteger("Attack", 2);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
			if(Input.GetMouseButtonDown(1)){
				Bow();
				animator.SetInteger("BowAttack", 2);

			}
			if(Input.GetMouseButtonUp(1)){
				animator.SetInteger("BowAttack", -1);
			}
		}
		else if (vertical < 0)
		{
			animator.SetInteger("Direction", 0);
			animator.SetFloat("Change", 1.0f);
			if(Input.GetMouseButtonDown(0)){
				Melee();
				animator.SetInteger("Attack", 0);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
			if(Input.GetMouseButtonDown(1)){
				Bow();
				animator.SetInteger("BowAttack", 0);
			}
			if(Input.GetMouseButtonUp(1)){
				animator.SetInteger("BowAttack", -1);
			}
		}
		else if (horizontal > 0)
		{
			animator.SetInteger("Direction", 3);
			animator.SetFloat("Change", 1.0f);
			if(Input.GetMouseButtonDown(0)){
				Melee();
				animator.SetInteger("Attack", 3);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
			if(Input.GetMouseButtonDown(1)){
				Bow();
				animator.SetInteger("BowAttack", 3);
			}
			if(Input.GetMouseButtonUp(1)){
				animator.SetInteger("BowAttack", -1);
			}
		}
		else if (horizontal < 0)
		{
			animator.SetInteger("Direction", 1);
			animator.SetFloat("Change", 1.0f);
			if(Input.GetMouseButtonDown(0)){
				Melee();
				animator.SetInteger("Attack", 1);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
			if(Input.GetMouseButtonDown(1)){
				Bow();
				animator.SetInteger("BowAttack", 1);
			}
			if(Input.GetMouseButtonUp(1)){
				animator.SetInteger("BowAttack", -1);
			}
		}
		else
		{
			animator.SetFloat("Change", 0.0f);
			if(Input.GetMouseButtonDown(0)){
				Melee();
				animator.SetInteger("Attack", animator.GetInteger("Direction"));
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
			if(Input.GetMouseButtonDown(1)){
				Bow();
				animator.SetInteger("BowAttack", animator.GetInteger("Direction"));
			}
			if(Input.GetMouseButtonUp(1)){
				animator.SetInteger("BowAttack", -1);
			}
		}
		
	}
	
	void Bow(){
		var screenPos = Input.mousePosition;
		screenPos.z = transform.position.z - Camera.main.transform.position.z;
		var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
				
		var q = Quaternion.FromToRotation(Vector3.up, worldPos - transform.position);
		var go = Instantiate(shot, transform.position, q);
	}
		
	void Melee(){
		Vector3 pos = transform.position;
		for(int i = 0; i < nearEnemy.Count; i++){
			Vector3 vec = nearEnemy[i].transform.position;
			Vector3 dir = vec - pos;
			if(Vector3.Dot(dir, transform.forward)<0.7){
				nearEnemy[i].GetComponent<enemyhealth>().TakeDamage(damage);
				if(nearEnemy[i].GetComponent<enemyhealth>().health < 0f){
					nearEnemy.Remove(nearEnemy[i]);
				}
			}
		}
	}
}
