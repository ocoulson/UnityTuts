using UnityEngine;
using System.Collections;

public class PlayerProjectile : Projectile {


	public GameObject explosion;

	override public void Hit ()
	{	
		Vector3 position = transform.position;
		Destroy(gameObject);
		GameObject boom = Instantiate(explosion, position, Quaternion.identity) as GameObject;

		new WaitForSeconds(0.5f);
		Destroy(boom);
	}
}
