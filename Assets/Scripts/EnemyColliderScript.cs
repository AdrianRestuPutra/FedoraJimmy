using UnityEngine;
using System.Collections;

public class EnemyColliderScript : MonoBehaviour {
	public string colliderCode;
	public GameObject gameObject;
	private float force;
	private float vectorX, vectorY;


	// Use this for initialization
	void Start () {
		force = gameObject.GetComponent<EnemyScript> ().force;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Wall") {
			if (colliderCode == "up") {
				print ("collide up");
				vectorX = Random.Range (-force, force);
				vectorY = Random.Range (-force, 0);
				Vector3 vectorTemp = new Vector3 (vectorX, vectorY, 0f);
				gameObject.GetComponent<EnemyScript> ().MoveEnemy (vectorTemp);
			} else if (colliderCode == "right") {
				print ("collide right");
				vectorX = Random.Range (-force, 0);
				vectorY = Random.Range (-force, force);
				Vector3 vectorTemp = new Vector3 (vectorX, vectorY, 0f);
				gameObject.GetComponent<EnemyScript> ().MoveEnemy (vectorTemp);
			} else if (colliderCode == "down") {
				print ("collide down");
				vectorX = Random.Range (-force, force);
				vectorY = Random.Range (0, force);
				Vector3 vectorTemp = new Vector3 (vectorX, vectorY, 0f);
				gameObject.GetComponent<EnemyScript> ().MoveEnemy (vectorTemp);
			} else if (colliderCode == "left") {
				print ("collide left");
				vectorX = Random.Range (0, force);
				vectorY = Random.Range (-force, force);
				Vector3 vectorTemp = new Vector3 (vectorX, vectorY, 0f);
				gameObject.GetComponent<EnemyScript> ().MoveEnemy (vectorTemp);
			} 
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
