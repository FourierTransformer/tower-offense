using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public GameObject shot;
	public float firerate;

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		Vector2 shotLook = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		if (vertical > 0)
		{
			animator.SetInteger("Direction", 2);
			animator.SetFloat("Change", 1.0f);
			if(Input.GetMouseButtonDown(0)){
				animator.SetInteger("Attack", 2);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
			if(Input.GetMouseButtonDown(1)){
				//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				var screenPos = Input.mousePosition;
				screenPos.z = transform.position.z - Camera.main.transform.position.z;
				var worldPos = Camera.main.ScreenToWorldPoint(screenPos);

				var q = Quaternion.FromToRotation(Vector3.up, worldPos - transform.position);
				var go = Instantiate(shot, transform.position, q);

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
				animator.SetInteger("Attack", 0);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
			if(Input.GetMouseButtonDown(1)){
				//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				var screenPos = Input.mousePosition;
				screenPos.z = transform.position.z - Camera.main.transform.position.z;
				var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
				
				var q = Quaternion.FromToRotation(Vector3.up, worldPos - transform.position);
				var go = Instantiate(shot, transform.position, q);
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
				animator.SetInteger("Attack", 3);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
			if(Input.GetMouseButtonDown(1)){
				//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				var screenPos = Input.mousePosition;
				screenPos.z = transform.position.z - Camera.main.transform.position.z;
				var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
				
				var q = Quaternion.FromToRotation(Vector3.up, worldPos - transform.position);
				var go = Instantiate(shot, transform.position, q);
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
				animator.SetInteger("Attack", 1);
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
			if(Input.GetMouseButtonDown(1)){
				//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				var screenPos = Input.mousePosition;
				screenPos.z = transform.position.z - Camera.main.transform.position.z;
				var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
				
				var q = Quaternion.FromToRotation(Vector3.up, worldPos - transform.position);
				var go = Instantiate(shot, transform.position, q);
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
				animator.SetInteger("Attack", animator.GetInteger("Direction"));
			}
			if(Input.GetMouseButtonUp(0)){
				animator.SetInteger("Attack", -1);
			}
			if(Input.GetMouseButtonDown(1)){
				//Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				var screenPos = Input.mousePosition;
				screenPos.z = transform.position.z - Camera.main.transform.position.z;
				var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
				
				var q = Quaternion.FromToRotation(Vector3.up, worldPos - transform.position);
				var go = Instantiate(shot, transform.position, q);
				animator.SetInteger("BowAttack", animator.GetInteger("Direction"));
			}
			if(Input.GetMouseButtonUp(1)){
				animator.SetInteger("BowAttack", -1);
			}
		}
	}
}
