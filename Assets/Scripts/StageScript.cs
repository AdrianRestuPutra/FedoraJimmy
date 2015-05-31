using UnityEngine;
using System.Collections;

public class StageScript : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
		Instantiate (player, Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
