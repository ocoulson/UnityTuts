using UnityEngine;
using System.Collections;

public class EnemyProjectile : Projectile
{
	private GameObject boom;
	public GameObject explosion;

	override public void Hit ()
	{	
		Vector3 position = transform.position;
		Destroy(gameObject);
		boom = Instantiate(explosion, position, Quaternion.identity) as GameObject;

	}
}
