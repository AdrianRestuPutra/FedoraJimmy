using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public Color[] color;
	public string[] colorCode;
	private string currentColorCode;
	public GameObject[] gameObjectEnemySprite;
	public float force = 8;
	private Vector3 currentVector;
	private Rigidbody2D rigidbody2D;
	private Animator animator;
	private bool upMove, downMove, leftMove, rightMove;
	public GameObject targetPlayer;
	public float radius = 10f;
	private float distanceToPlayer;
	private bool isFreeMoving, isChasing;

	private float startTime = 0f;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		int colorIndex = Random.Range (0, color.Length);
		currentColorCode = colorCode [colorIndex];
		for (int i = 0; i < gameObjectEnemySprite.Length; i++) {
			gameObjectEnemySprite[i].GetComponent<SpriteRenderer>().color = color[colorIndex];
		}

		isFreeMoving = true;
		isChasing = false;
		float tempX = Random.Range (-force, force);
		float tempY = Random.Range (-force, force);
		currentVector = new Vector3 (tempX, tempY, 0f);
	}

	void FixedUpdate () {
		CalculateDistanceToPlayer ();
//		MoveEnemy (currentVector);
	}
	
	// Update is called once per frame
	void Update () {
//		CalculateDistanceToPlayer ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			if (currentColorCode == collider.gameObject.GetComponent<ChangeColorScript>().currentColorCode) {
				SelfDestroy ();
			} else {
				print("win");
			}
		}
	}

	public void MoveEnemy (Vector3 vector) {
		currentVector = vector;
//		print (currentVector + "");
		rigidbody2D.velocity = currentVector;
	}

	void CalculateDistanceToPlayer () {
		distanceToPlayer = Vector3.Distance (transform.position, targetPlayer.transform.position);
		print (distanceToPlayer+"");

		if (distanceToPlayer <= radius * 2) {
			if (!isChasing) {
				startTime = Time.time;
				isChasing = true;
			}
			animator.SetBool ("Walk", true);
			currentVector = Vector3.zero;
			rigidbody2D.velocity = currentVector;

			float distCovered = 0.08f;
			float fracJourney = distCovered / distanceToPlayer;
			transform.position = Vector3.Lerp(transform.position, targetPlayer.transform.position, fracJourney);
			isFreeMoving = true;
		} else {
//			animator.SetBool ("Walk", false);
			isChasing = false;
			if (isFreeMoving) {
				float tempX = Random.Range (-force, force);
				float tempY = Random.Range (-force, force);
				currentVector.x = tempX;
				currentVector.y = tempY;
				currentVector.z = 0f;
				isFreeMoving = false;
			}
			MoveEnemy(currentVector);
		}
	}

	void SelfDestroy () {
		Destroy (gameObject);
	}
}
