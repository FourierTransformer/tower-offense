using UnityEngine;
using System.Collections;

public class enemyhealth : MonoBehaviour {

	public float health = 100f;
	
	private bool enemyDead;
	private Animator anim;
	
	void Update () {
		// If health is less than or equal to 0...
		if(health <= 0f)
		{
			// ... and if the player is not yet dead...
			if(!enemyDead)
				// ... call the PlayerDying function.
				EnemyDying();
		}
	}
	
	void EnemyDying(){
		enemyDead = true;
		Destroy(gameObject);

	}
	
	public void TakeDamage(float amount){
				health -= amount;
		}
}
