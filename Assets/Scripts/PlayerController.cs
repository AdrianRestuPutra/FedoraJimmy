using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float force = 10;
	private Rigidbody2D rigidbody2D;
	//input
	private bool upMove, downMove, leftMove, rightMove;
	public float constraint = 0.5f;

	private Animator animator;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>(); 
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		Vector3 currentVector = Vector3.zero;
		if (rightMove) {
			currentVector.x += force;
			animator.SetBool("Walk", true);
		} if (leftMove) {
			currentVector.x -= force;
			animator.SetBool("Walk", true);
		} if (upMove) {
			currentVector.y += force;
			animator.SetBool("Walk", true);
		} if (downMove) {
			currentVector.y -= force;
			animator.SetBool("Walk", true);
		} if (currentVector.Equals(Vector3.zero)) {
			animator.SetBool("Walk", false);
		}
		rigidbody2D.velocity = currentVector;
//		MovePlayer ();
	}

	// Update is called once per frame
	void Update () {
		InputManager ();

	}

	void InputManager() {
//		upMove = Input.GetKey (KeyCode.UpArrow);
//		downMove = Input.GetKey (KeyCode.DownArrow);
//		rightMove = Input.GetKey (KeyCode.RightArrow);
//		leftMove = Input.GetKey (KeyCode.LeftArrow);

		//unity editor
		if (Input.GetMouseButton (0)) {
			upMove = downMove = rightMove = leftMove = false;
			Vector3 touchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			print(Mathf.Abs (touchPosition.y - transform.position.y)+"");
			if(Mathf.Abs (touchPosition.y - transform.position.y) > constraint / 2) {
				if (touchPosition.y > transform.position.y) upMove = true;
				if (touchPosition.y < transform.position.y) downMove = true;
			}
			if(Mathf.Abs (touchPosition.x - transform.position.x) > constraint / 2) {
				if (touchPosition.x > transform.position.x) rightMove = true;
				if (touchPosition.x < transform.position.x) leftMove = true;
			}
		} else {
			upMove = downMove = rightMove = leftMove = false;
		}

		//android
//		if (Input.touchCount > 0) {
//			upMove = downMove = rightMove = leftMove = false;
//			Vector3 touchPosition = Camera.main.ScreenToWorldPoint (Input.touches[0].position);
//			print(Mathf.Abs (touchPosition.y - transform.position.y)+"");
//			if(Mathf.Abs (touchPosition.y - transform.position.y) > constraint / 2) {
//				if (touchPosition.y > transform.position.y) upMove = true;
//				if (touchPosition.y < transform.position.y) downMove = true;
//			}
//			if(Mathf.Abs (touchPosition.x - transform.position.x) > constraint / 2) {
//				if (touchPosition.x > transform.position.x) rightMove = true;
//				if (touchPosition.x < transform.position.x) leftMove = true;
//			}
//		} else {
//			upMove = downMove = rightMove = leftMove = false;
//		}
	}

	void MovePlayer () {
		if (Input.GetMouseButton(0)) {
			Vector3 destPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			float distance = Vector3.Distance(transform.position, destPosition);

			Vector3 velocity = Vector3.zero;
			transform.position = Vector3.SmoothDamp(transform.position, destPosition, ref velocity, 0.3f);
		}
	}
}
