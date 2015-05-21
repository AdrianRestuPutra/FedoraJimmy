using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public Color[] color;
	public GameObject[] gameObjectEnemySprite;
	public float force = 8;
	private Rigidbody2D rigidbody2D;
	private Animator animator;
	private bool upMove, downMove, leftMove, rightMove;
	public GameObject targetPlayer;
	public float radius = 10f;
	private float distanceToPlayer;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		int colorIndex = Random.Range (0, color.Length);
		for (int i = 0; i < gameObjectEnemySprite.Length; i++) {
			gameObjectEnemySprite[i].GetComponent<SpriteRenderer>().color = color[colorIndex];
		}
	}

	void FixedUpdate () {
		Vector3 vector = new Vector3 (0, 0, 0);
		if (rightMove) {
			vector.x += force;
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
		CalculateDistanceToPlayer ();
	}

	void CalculateDistanceToPlayer () {
		distanceToPlayer = Vector3.Distance (transform.position, targetPlayer.transform.position);
//		print (distanceToPlayer);

		if (distanceToPlayer <= radius * 2) {
			animator.SetBool ("Walk", true);
		} else {
			animator.SetBool ("Walk", false);
		}
	}
}
