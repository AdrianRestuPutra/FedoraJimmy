using UnityEngine;
using System.Collections;

public class OrderCalculator : MonoBehaviour {
	public GameObject[] gameObjectSprite;
	private bool isColliding;
	private Collider2D collider;

	// Use this for initialization
	void Start () {
		isColliding = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isColliding) {
			if(collider.gameObject.transform.position.y > transform.position.y) {
//				print("atas");
				for (int i = 0; i < gameObjectSprite.Length; i++) {
					gameObjectSprite[i].GetComponent<ChangeOrderScript>().upOrder();
				}
			} else {
//				print("bawah");
				for (int i = 0; i < gameObjectSprite.Length; i++) {
					gameObjectSprite[i].GetComponent<ChangeOrderScript>().downOrder();
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		print("collide order "+gameObject.transform.name);
		this.collider = collider;
		isColliding = true;
//		if(collider.gameObject.transform.position.y > transform.position.y) {
//			print("atas");
////			for (int i = 0; i < gameObjectSprite.Length; i++) {
////				gameObjectSprite[i].GetComponent<ChangeOrderScript>().upOrder();
////			}
//		} else {
//			print("bawah");
//		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		isColliding = false;
	}
}
