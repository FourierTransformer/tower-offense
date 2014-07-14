using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerController : MonoBehaviour {

	public GameObject shot;
	public float damage = 15f;

	private Animator animator;
	private List<GameObject> nearEnemy = new List<GameObject>();
	private Quaternion q;

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
		
	/*void OnGUI(){
			GUI.Box(new Rect(10,10,150,20), q + "");
		}*/

	// Update is called once per frame
	void Update () {
	
		var screenPos = Input.mousePosition;
		screenPos.z = transform.position.z - Camera.main.transform.position.z;
		var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
		q = Quaternion.FromToRotation(Vector3.up, worldPos - transform.position);
		
		
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		if((q.z >= -0.5F && q.z <= 0.5F) && q.w > 0.8F)  
		{
			animator.SetInteger("Direction", 2);
			if(vertical != 0 || horizontal != 0){
				animator.SetFloat("Change", 1.0f);
			} else {
				animator.SetFloat("Change", 0.0f);
			}
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
		else if ((q.w >= -0.5F && q.w <= 0.4F) && q.z > 0.9F)
		{
			animator.SetInteger("Direction", 0);
			if(vertical != 0 || horizontal != 0){
				animator.SetFloat("Change", 1.0f);
			} else {
				animator.SetFloat("Change", 0.0f);
			}
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
		else if(q.z <= -0.5F && q.w > 0.5F)
		{
			animator.SetInteger("Direction", 3);
			if(vertical != 0 || horizontal != 0){
				animator.SetFloat("Change", 1.0f);
			} else {
				animator.SetFloat("Change", 0.0f);
			}
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
		else if((q.z >= 0.5F && q.z <= 0.9F) && q.w >= 0.4F)
		{
			animator.SetInteger("Direction", 1);
			if(vertical != 0 || horizontal != 0){
				animator.SetFloat("Change", 1.0f);
			} else {
				animator.SetFloat("Change", 0.0f);
			}
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
	}
	
	
	void Bow(){
		var screenPos = Input.mousePosition;
		screenPos.z = transform.position.z - Camera.main.transform.position.z;
		var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
				
		var q = Quaternion.FromToRotation(Vector3.up, worldPos - transform.position);
		var go = Instantiate(shot, transform.position, q);
	}
		
	void Melee(){
		var screenPos = Input.mousePosition;
		screenPos.z = transform.position.z - Camera.main.transform.position.z;
		var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
		
		Vector2 pos = transform.position;
		for(int i = 0; i < nearEnemy.Count; i++){
			Vector2 vec = nearEnemy[i].transform.position;
			Vector2 dir = vec - pos;
			if(Vector2.Dot(dir, worldPos - transform.position) > .7){
				nearEnemy[i].GetComponent<enemyhealth>().TakeDamage(damage);
				if(nearEnemy[i].GetComponent<enemyhealth>().health < 0f){
					nearEnemy.Remove(nearEnemy[i]);
				}
			}
		}
	}
}
