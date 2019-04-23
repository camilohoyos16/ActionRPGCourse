using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {

	public void FireProjectile(Projectile projectile, float initialVelocity, Vector2 direction, int damage)
    {
        Projectile newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.gameObject.transform.SetParent(GameManager.Instance.tempObjectsContent);
        newProjectile.initialVelocity = initialVelocity;
        newProjectile.initialDirection = direction;
        newProjectile.damage = damage;
        float angleRotation = Mathf.Atan2(direction.y, direction.x);
        newProjectile.transform.Rotate(0, 0, angleRotation * Mathf.Rad2Deg);
    }
}
