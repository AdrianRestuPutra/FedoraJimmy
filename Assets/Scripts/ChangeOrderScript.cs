using UnityEngine;
using System.Collections;

public class ChangeOrderScript : MonoBehaviour {
//	public GameObject targetPlayer;
	public int defaultOrder;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().sortingOrder = defaultOrder - (int)Mathf.Ceil(transform.position.y);
	}

//	public void upOrder () {
//		GetComponent<SpriteRenderer> ().sortingOrder = changeUpOrder;
//	}
//
//	public void downOrder () {
//		GetComponent<SpriteRenderer> ().sortingOrder = changeDownOrder;
//	}
//
//	public void revertOrder () {
//		GetComponent<SpriteRenderer> ().sortingOrder = changeDownOrder;
//	}
}
