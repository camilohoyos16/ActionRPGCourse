using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyInput))]
public class EnemiesAI : Enemy
{
    protected Abilities m_Abilities;
    protected EnemyInput m_EnemyInput;
    private Attacker m_Attacker;
    protected SpriteRenderer m_Sprite;
    private bool isDeath;
    private bool isAttacking;
    private bool isInCombat;
    private Animator m_Animator;
    private Vector2 attackDirection;
    private int movingHash;
    private int deathHash;
    private int attackHash;

    [SerializeField] private float sightDistance;
    [SerializeField] private float attackDistance;

    private void Start()
    {
        m_Abilities = GetComponent<Abilities>();
        m_Sprite = GetComponent<SpriteRenderer>();
        m_EnemyInput = GetComponent<EnemyInput>();
        m_Animator = GetComponent<Animator>();
        m_Attacker = GetComponent<Attacker>();
        movingHash = Animator.StringToHash("moving");
        attackHash = Animator.StringToHash("attack");
        deathHash = Animator.StringToHash("death");
        GetEnemyName();
        Instantiate(spawnVFX, transform);
    }

    private void Update()
    {
        Behaviour();
    }

    protected void Behaviour()
    {
        if (!isDeath) {
            if (!isAttacking && m_EnemyInput.playerDistance < attackDistance) {
                DoAttack();
            } else if (!isAttacking && ( isInCombat || m_EnemyInput.playerDistance < sightDistance )) {
                MoveToPlayer();
            } else {
                m_Animator.SetBool(movingHash, false);
            }
        }
    }

    private void DoAttack()
    {
        int attackProbability = Random.Range(0, 100);
        m_Animator.SetBool(movingHash, false);
        if (attackProbability > 95) {
            attackDirection = m_EnemyInput.directionToPlayer;
            isInCombat = true;
            isAttacking = true;
            m_Animator.SetTrigger(attackHash);
        }
    }

    private void MoveToPlayer()
    {
        m_Animator.SetBool(movingHash, true);
        FlipSprite();
        transform.position += (Vector3)m_EnemyInput.directionToPlayer.normalized * m_Attributes.velocity * Time.deltaTime;
    }

    public virtual void EnemyAttack()
    {
        m_Attacker.Attack(attackDirection, m_Attributes.attack);
    }

    protected virtual void FlipSprite()
    {
        if (m_EnemyInput.horizontal < 0) {
            m_Sprite.flipX = true;
        } else {
            m_Sprite.flipX = false;
        }
    }

    private void SetAttackToFalse()
    {
        isInCombat = false;
        isAttacking = false;
    }

    public void Die()
    {
        isDeath = true;
        m_Animator.SetBool(deathHash, true);
    }
}
