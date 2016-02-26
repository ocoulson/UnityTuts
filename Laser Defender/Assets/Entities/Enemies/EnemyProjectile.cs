using UnityEngine;
using System.Collections;

public class EnemyProjectile : Projectile
{

	override public void Hit() {
		//insert code
		Destroy(gameObject);
	}
}
