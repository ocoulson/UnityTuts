using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 1f;

	float maxX;
	float minX;

	void Start ()
	{
		float zDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,zDistance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,zDistance));

		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;
	}

	void Update ()
	{
		Vector3 spritePos = this.transform.position;

		bool leftKey = Input.GetKey (KeyCode.LeftArrow);
		bool rightKey = Input.GetKey (KeyCode.RightArrow);


		if (leftKey && !rightKey) {
			
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (rightKey && !leftKey) {

			this.transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp(transform.position.x,minX,maxX);

		transform.position = new Vector3(newX, transform.position.y, transform.position.z); 
//		bool upKey = Input.GetKey (KeyCode.UpArrow);
//		bool downKey = Input.GetKey (KeyCode.DownArrow);
//		if (upKey && !downKey) {
//			this.transform.position += Vector3.up * speed * Time.deltaTime;
//		} else if (downKey && !upKey) {
//			this.transform.position += Vector3.down * speed * Time.deltaTime;
//		}

	}
}
