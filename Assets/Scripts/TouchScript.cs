using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {
	private float screenWidth, screenHeight;

	// Use this for initialization
	void Start () {
		screenWidth = (float)Screen.width;
		screenHeight = (float)Screen.height;
		print ("w : " + screenWidth + " h : " + screenHeight);
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.touchCount > 0) {
//			Touch touch = Input.GetTouch(0);
//			print(touch.position);
//		}
		if (Input.GetMouseButtonDown(0)) {
			Vector3 tempPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		}
	}
}
