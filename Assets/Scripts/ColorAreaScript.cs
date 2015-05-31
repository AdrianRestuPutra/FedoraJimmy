using UnityEngine;
using System.Collections;

public class ColorAreaScript : MonoBehaviour {
	public Color color;
	public string colorCode;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent<ChangeColorScript>().changePlayerColor(color, colorCode);
		}
	}
}
