using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;

	void Update ()
	{
		Vector3 spritePos = this.transform.position;

		bool leftKey = Input.GetKey (KeyCode.LeftArrow);
		bool rightKey = Input.GetKey (KeyCode.RightArrow);
		bool upKey = Input.GetKey (KeyCode.UpArrow);
		bool downKey = Input.GetKey (KeyCode.DownArrow);

		if (leftKey && !rightKey) {
			
			this.transform.position += new Vector3(-speed * Time.deltaTime, 0,0);
		} else if (rightKey && !leftKey) {

			this.transform.position += new Vector3(speed * Time.deltaTime, 0,0);
		}

		if (upKey && !downKey) {
			this.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
		} else if (downKey && !upKey) {
			this.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
		}

	}
}
