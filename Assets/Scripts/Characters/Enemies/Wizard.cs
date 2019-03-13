using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : EnemiesAI {

    public Projectile projectile;

    public override void EnemyAttack()
    {
        m_Abilities.FireProjectile(projectile, projectile.initialVelocity, m_EnemyInput.directionToPlayer, m_Attributes.attack);
    }

    protected override void FlipSprite()
    {
        if (m_EnemyInput.horizontal < 0) {
            m_Sprite.flipX = false;
        } else {
            m_Sprite.flipX = true;
        }
    }
}
