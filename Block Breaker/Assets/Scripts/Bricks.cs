using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public static int breakableCount = 0;

	public AudioClip boing;
	public AudioClip[] brickBreak;
	public Sprite[] HitSprites;

	private  int totalHits;
	private LevelManager levelManager;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		totalHits = 0;

	}

	void OnCollisionExit2D (Collision2D col) {
		if (isBreakable) {
			HandleHits();
		}

	}

	void HandleHits () {
		totalHits++;
		int maxHits = HitSprites.Length +1;
		if (totalHits >= maxHits) {
			breakableCount --;
			Destroy (gameObject);
			levelManager.BrickDestroyed();
	
			AudioSource.PlayClipAtPoint(brickBreak[Random.Range(0, 4)], transform.position);
		} else {
			LoadSprite();
			AudioSource.PlayClipAtPoint(boing, transform.position);
		}
	}

	void LoadSprite () {
		int spriteIndex = totalHits - 1;
		if (HitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
		}
	} 


}
