using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
	public GameObject enemy;
	public GameObject enemy2;
	public Vector3 spawnValues;
	//public Vector3 spawnValues2;
	public int enemyCount;
	public int enemyCount2;
	private int mapMaxHeight = -29;
	private int mapMaxWidth = 29;
	private int mapMinHeight = -1;
	private int mapMinWidth = 1;
	//public float spawnWait;
	//public float startWait;
	public float HealthModifier;
	public float SpeedModifier;
	public float levelWait;

	/* get health to modify (not working), 
	 * don't spawn on lake, 
	 * spawn all enemies without multiple for loops? 
	 * spawned enemies aren't hit by arrows */
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		//yield return new WaitForSeconds (startWait);
		while (true)
		{

			if (HealthModifier > 0)
			{
				//changes health by multiplying the modifier and current health
				enemy.GetComponent<enemyhealth>().health = enemy.GetComponent<enemyhealth>().health * HealthModifier;
			}
			/*
			if (SpeedModifier > 0)
			{
				enemy.speed = HealthModifier * enemy.speed;
			}
			*/
			for (int i = 0; i < enemyCount; i++)
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Vector3 spawnPosition = new Vector3 
					(Random.Range (mapMinWidth, mapMaxWidth), Random.Range (mapMinHeight, mapMaxHeight), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				//yield return new WaitForSeconds (spawnWait);
			}
			for (int i = 0; i < enemyCount2; i++)
			{
				Vector3 spawnPosition = new Vector3 
					(Random.Range (mapMinWidth, mapMaxWidth), Random.Range (mapMinHeight, mapMaxHeight), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy2, spawnPosition, spawnRotation);
				//yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (levelWait);
		}
	}
}