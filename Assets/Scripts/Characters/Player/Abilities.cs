using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {

	public void FireProjectile(Projectile projectile, float initialVelocity, Vector2 direction, int damage)
    {
        Projectile newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.gameObject.transform.SetParent(transform);
        newProjectile.initialVelocity = initialVelocity;
        newProjectile.initialDirection = direction;
        newProjectile.damage = damage;
    }
}
