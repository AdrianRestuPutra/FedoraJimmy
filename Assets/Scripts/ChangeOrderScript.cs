using UnityEngine;
using System.Collections;

public class ChangeOrderScript : MonoBehaviour {
//	public GameObject targetPlayer;
	public int defaultOrder, changeUpOrder, changeDownOrder;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void upOrder () {
		GetComponent<SpriteRenderer> ().sortingOrder = changeUpOrder;
	}

	public void downOrder () {
		GetComponent<SpriteRenderer> ().sortingOrder = changeDownOrder;
	}

	public void revertOrder () {
		GetComponent<SpriteRenderer> ().sortingOrder = changeDownOrder;
	}
}
