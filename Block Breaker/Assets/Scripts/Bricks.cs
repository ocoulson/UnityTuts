using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public static int breakableCount = 0;

	public AudioClip bounce;
	public AudioClip[] brickBreak;
	public Sprite[] HitSprites;

	public GameObject smoke;

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
			SmokeEffects();
			Destroy (gameObject);
			levelManager.BrickDestroyed();
			PlayAudio();
		} else {
			LoadSprite();
			AudioSource.PlayClipAtPoint(bounce, transform.position);
		}
	}

	void SmokeEffects() {
		GameObject puff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject; 
		puff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void PlayAudio() {
		int i = Random.Range(0, 4);
		AudioSource.PlayClipAtPoint(brickBreak[i], transform.position);
	}

	void LoadSprite () {
		int spriteIndex = totalHits - 1;
		if (HitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = HitSprites [spriteIndex];
		} else {
			Debug.LogError("Brick Sprite Missing");
		}
	} 


}
