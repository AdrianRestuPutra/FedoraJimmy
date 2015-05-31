using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
	public GameObject baloon;
	public GameObject playButton;
	public GameObject cloud;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayClicked () {
		baloon.GetComponent<Animator>().SetBool("IsLoading", true);
//		playButton.GetComponent<Animator>.SetBool("ClickDown", true);
		cloud.GetComponent<Animator> ().SetBool ("IsLoading", true);
	}
}
