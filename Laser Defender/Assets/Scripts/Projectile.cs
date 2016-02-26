using UnityEngine;
using System.Collections;

abstract public class Projectile : MonoBehaviour {

	public float damage = 100f;

	public float getDamage ()
	{
		return damage;
	}

	abstract public void Hit();
}
