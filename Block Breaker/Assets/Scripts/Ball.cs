using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	 
	// Use this for initialization
	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;
		print(paddleToBallVector.y);
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
}
