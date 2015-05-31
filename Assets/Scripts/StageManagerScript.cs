using UnityEngine;
using System.Collections;

public class StageManagerScript : MonoBehaviour {
	public int enemyCount;
	private int enemySpawned;
	public float spawnTimeRange = 5f;
	public GameObject[] enemyType;
	public GameObject jimmy;
	public GameObject spawnArea;


	// Use this for initialization
	void Start () {
		enemySpawned = 0;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimeRange -= Time.deltaTime;
		if (spawnTimeRange <= 0) {
			spawnTimeRange = 5f;

			if (enemySpawned < enemyCount) {
				//spawn enemy
				int enemyIndex = Random.Range(0, enemyType.Length);
				GameObject g = (GameObject)Instantiate(enemyType[enemyIndex], spawnArea.transform.position, Quaternion.identity);
				g.GetComponent<EnemyScript>().targetPlayer = jimmy;
				enemySpawned++;
			}
		}
	}

}
