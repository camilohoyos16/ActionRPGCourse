using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : EnemiesAI {

    public override void EnemyAttack()
    {
        Debug.Log("Attacking");
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
