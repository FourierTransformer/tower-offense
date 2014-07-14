using UnityEngine;
using System.Collections;

public class enemyhealth : MonoBehaviour {

	public float health = 100f;
	public float healthBarLength;
	
	public float maxHealth = 100f;
	private bool enemyDead;
	private Animator anim;
	
	void Start(){
		healthBarLength = 45;
	}
	
	void Update () {
		AdjustCurrentHealth();
		// If health is less than or equal to 0...
		if(health <= 0f)
		{
			// ... and if the player is not yet dead...
			if(!enemyDead)
				// ... call the PlayerDying function.
				EnemyDying();
		}
	}
	
	void OnGUI() {
	if(health < maxHealth){
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint(transform.position);
		GUI.Box(new Rect(targetPos.x-22, Screen.height-(targetPos.y+20), healthBarLength, 5),"");
		}
	}

	public void AdjustCurrentHealth(){
		healthBarLength = 45 * (health/maxHealth);
	}
	
	void EnemyDying(){
		enemyDead = true;
		Destroy(gameObject);

	}
	
	public void TakeDamage(float amount){
				health -= amount;
		}
}
