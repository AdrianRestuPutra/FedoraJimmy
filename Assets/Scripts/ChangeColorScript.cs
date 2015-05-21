using UnityEngine;
using System.Collections;

public class ChangeColorScript : MonoBehaviour {
	private Color defaultColor = new Color(0.25f, 0.3f, 0.64f);
	public GameObject[] gameObjectSprite;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < gameObjectSprite.Length; i++) {
			gameObjectSprite[i].GetComponent<SpriteRenderer>().color = defaultColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changePlayerColor (Color color) {
		for (int i = 0; i < gameObjectSprite.Length; i++) {
			gameObjectSprite[i].GetComponent<SpriteRenderer>().color = color;
		}
	}
}
