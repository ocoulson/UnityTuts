using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public AudioClip boing;

	private bool hasStarted;

	private Ball ball;

	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		print(ball);

	}

	// Update is called once per frame
	void Update () {
		hasStarted =  ball.HasStarted();
		if (autoPlay) {
			AutoPlay();
		} else {
			MoveWithMouse();
		}

	}

	void AutoPlay () {
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y , 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, 1f, 15f);
		this.transform.position = paddlePos;
	}

	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y , 0f);

		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);
		this.transform.position = paddlePos;
//		if (Input.GetMouseButtonDown (0)) {
//				hasStarted = true;
//			}
	}
	void OnCollisionEnter2D (Collision2D col) {
		if (hasStarted) {
			AudioSource.PlayClipAtPoint(boing, transform.position);
		}
	}
}
