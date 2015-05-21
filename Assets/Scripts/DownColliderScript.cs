using UnityEngine;
using System.Collections;

public class DownColliderScript : MonoBehaviour {
	public GameObject[] gameObjectSprite;
	public GameObject otherOrderCollider;
	public bool isColliding;
	private Collider2D collider;
	
	// Use this for initialization
	void Start () {
		isColliding = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isColliding) {
//			print("bawah");
			for (int i = 0; i < gameObjectSprite.Length; i++) {
				gameObjectSprite[i].GetComponent<ChangeOrderScript>().downOrder();
			}

		}
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		print(gameObject.transform.name+"");
		this.collider = collider;

		bool flag = otherOrderCollider.GetComponent<UpColliderScript> ().isColliding;
		print(gameObject.transform.name+" "+flag);
		
		if (!flag) {
			isColliding = true;
		}
	}
	
	void OnTriggerExit2D (Collider2D collider) {
		isColliding = false;

		bool flag = otherOrderCollider.GetComponent<DownColliderScript> ().isColliding;
		if (!flag) {
			for (int i = 0; i < gameObjectSprite.Length; i++) {
				gameObjectSprite [i].GetComponent<ChangeOrderScript> ().revertOrder ();
			}
		}
	}
}
