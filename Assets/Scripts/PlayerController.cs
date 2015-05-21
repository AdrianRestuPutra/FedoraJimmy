using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float force = 10;
	private Rigidbody2D rigidbody2D;
	//input
	private bool upMove, downMove, leftMove, rightMove;

	private Animator animator;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>(); 
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		Vector3 vector = new Vector3 (0, 0, 0);
		if (rightMove) {
			vector.x += force;
			animator.SetBool("Walk", true);
		} if (leftMove) {
			vector.x -= force;
			animator.SetBool("Walk", true);
		} if (upMove) {
			vector.y += force;
			animator.SetBool("Walk", true);
		} if (downMove) {
			vector.y -= force;
			animator.SetBool("Walk", true);
		} if (vector.Equals(Vector3.zero)) {
			animator.SetBool("Walk", false);
		}
		rigidbody2D.velocity = vector;
	}

	// Update is called once per frame
	void Update () {
		InputManager ();
	}

	void InputManager() {
		upMove = Input.GetKey (KeyCode.UpArrow);
		downMove = Input.GetKey (KeyCode.DownArrow);
		rightMove = Input.GetKey (KeyCode.RightArrow);
		leftMove = Input.GetKey (KeyCode.LeftArrow);


	}
}
