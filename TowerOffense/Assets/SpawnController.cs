using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
	public GameObject enemy;
	public GameObject enemy2;
	public Vector3 spawnValues;
	public Vector3 spawnValues2;
	public int enemyCount;
	public int enemyCount2;
	//public float spawnWait;
	//public float startWait;
	public float HealthModifier;
	public float SpeedModifier;
	public float levelWait;
	
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		//yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < enemyCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				//yield return new WaitForSeconds (spawnWait);
			}
			for (int i = 0; i < enemyCount2; i++)
			{
				Vector3 spawnPosition2 = new Vector3 (Random.Range (-spawnValues2.x, spawnValues2.x), spawnValues2.y, spawnValues2.z);
				Quaternion spawnRotation2 = Quaternion.identity;
				Instantiate (enemy2, spawnPosition2, spawnRotation2);
				//yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (levelWait);
		}
	}
}