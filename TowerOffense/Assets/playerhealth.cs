using UnityEngine;
using System.Collections;

public class playerhealth : MonoBehaviour {

	public float health = 100f;

	private Animator anim;
	private bool playerDead;
	private MovementNew playerMovement;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		playerMovement = GetComponent<MovementNew> ();
	}
	
	// Update is called once per frame
	void Update () {
		// If health is less than or equal to 0...
		if(health <= 0f)
		{
			// ... and if the player is not yet dead...
			if(!playerDead)
				// ... call the PlayerDying function.
				PlayerDying();
		}
	}

	void PlayerDying(){
		playerDead = true;
		anim.SetBool ("dead", playerDead);
		playerMovement.speed = 0f;

	}

	public void TakeDamage(float amount){
				health -= amount;
		}
}
