using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	int enemiesCounter = 0;
	public int enemiesPerLevel;
	public float enemyLimitRate;
	public float spawnRateIncrease;
	public float waveWaitingTime;
	public float startWaitingTime;
	public float spawnWaitingTime;

	public int playerScore;


	// Use this for initialization
	void Start ()
	{
		StartCoroutine (spawnWaves ());
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

	

	

	}

	IEnumerator  spawnWaves ()
	{
		yield return new WaitForSeconds (startWaitingTime);

		for (int i = 0; i<enemiesPerLevel; i++) {
			Vector3 pos = new Vector3 (Random.Range (-5, 5), 9);
			Instantiate (Resources.Load ("Enemies/EnemyParachute"), pos, Quaternion.identity);
			enemiesCounter++;
			if (verifySpawnRate ()) {
				spawnWaitingTime -= spawnRateIncrease;
			}
			yield return new WaitForSeconds (spawnWaitingTime);
		}
		yield return new WaitForSeconds (waveWaitingTime);
	}

	private bool verifySpawnRate ()
	{
		return spawnWaitingTime > 0.1 && (enemiesCounter != 0 && enemiesCounter % enemyLimitRate == 0);
	}
}
