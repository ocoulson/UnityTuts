using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	 
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			//Lock the ball relative to the paddle until mouse press
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//Mouse press launches ball  
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				print ("Mouse clicked, launching ball");

				this.GetComponent<Rigidbody2D> ().velocity = new Vector3 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		Vector2 tweak = new Vector2 (Random.Range (-0.2f, 0.2f), Random.Range (-0.2f, 0.2f));

		if (hasStarted) {
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}

	public bool HasStarted () {
		return hasStarted;
	}

}
