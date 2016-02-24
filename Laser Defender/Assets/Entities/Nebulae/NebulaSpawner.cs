using UnityEngine;
using System.Collections;

public class NebulaSpawner : MonoBehaviour {
	public float width = 10f;
	public float height = 5f;

	public GameObject[] Nebulae;

	public float timer = 0;

	private GameObject nebula;
	private float nebulaSpawnRate = 0.05f;

	private float nebulaDuration;

	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	
	// Update is called once per frame
	void Update ()
	{
		float probability = Time.deltaTime * nebulaSpawnRate;
		if (nebula) {
			timer += Time.deltaTime;
		}

		if ((Random.value < probability) && nebula == null) {
			
			int random = Random.Range (0, Nebulae.Length-1);
			nebula = Instantiate (Nebulae [random], transform.position, Quaternion.identity) as GameObject;
			nebula.transform.parent = transform;
			nebula.transform.Rotate (new Vector3 (90f, 0));
			nebulaDuration = (Random.Range(8f, 15f));
		}

		if (timer > nebulaDuration) {
			nebula.GetComponent<ParticleSystem> ().Stop ();
		}

		if (timer > nebulaDuration + 12f) {
			Destroy(nebula);
			nebula = null;
			timer = 0;
		} 
	}
}
