using UnityEngine;
using System.Collections;

public class enemyhealth : MonoBehaviour {

	public float health = 100f;
	public float healthBarLength;
	
	private float maxHealth = 100f;
	private bool enemyDead;
	private Animator anim;
	
	void Start(){
		healthBarLength = Screen.width/8;
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
		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint(transform.position);
		GUI.Box(new Rect(targetPos.x-65, Screen.height-(targetPos.y+30), healthBarLength, 20), health/maxHealth*100 + "%");
	}

	public void AdjustCurrentHealth(){
		healthBarLength = (Screen.width/8) * (health/maxHealth);
	}
	
	void EnemyDying(){
		enemyDead = true;
		Destroy(gameObject);

	}
	
	public void TakeDamage(float amount){
				health -= amount;
		}
}
