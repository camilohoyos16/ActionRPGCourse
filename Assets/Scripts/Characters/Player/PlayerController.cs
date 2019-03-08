using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Attributes m_Attributes;
    private InputPlayer m_InputPlayer;
    private Transform m_Transform;
    private Rigidbody2D m_RigidBody2D;
    private Animator m_Animator;
    private Attacker m_Attacker;

    private float horizontal;
    private float vertical;
    private int movingHashCode;

    // Use this for initialization
    void Start() {
        m_InputPlayer = GetComponent<InputPlayer>();
        m_Transform = GetComponent<Transform>();
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_Attacker = GetComponent<Attacker>();
        movingHashCode = Animator.StringToHash("moving");
    }

    private void Update() {
        horizontal = m_InputPlayer.horizontalAxis;
        vertical = m_InputPlayer.verticalAxis;

        if (vertical != 0 || horizontal != 0) {
            m_Animator.SetFloat("x", horizontal);
            m_Animator.SetFloat("y", vertical);
            m_Animator.SetBool("moving", true);
        } else {
            m_Animator.SetBool(movingHashCode, false);
        }

        if (Input.GetButtonDown("Attack")) {
            m_Animator.SetBool("attacking", true);

        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (m_Animator.GetBool("attacking")) {
            m_RigidBody2D.velocity = Vector2.zero;
        } else {
            Vector2 velocityVector = new Vector2(horizontal, vertical) * m_Attributes.velocity;
            m_RigidBody2D.velocity = velocityVector;
        }
    }

    public void AttackController() {
        m_Attacker.Attack(m_InputPlayer.directionSightVector, m_Attributes.attack);
        m_Animator.SetBool("attacking", false);
    }
}
