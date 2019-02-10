using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attributes))]
public class PlayerController : MonoBehaviour {

    private InputPlayer m_InputPlayer;
    private Transform m_Transform;
    private Rigidbody2D m_RigidBody2D;
    private Animator m_Animator;
    private Attributes m_Attributes;
    private Attacker m_Attacker;

    private float horizontal;
    private float vertical;
    private bool backwards;
    private int movingHashCode;

    // Use this for initialization
    void Start() {
        m_Attributes = GetComponent<Attributes>();
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
        backwards = vertical > 0;

        if (vertical != 0 || horizontal != 0) {
            m_Animator.SetFloat("x", horizontal);
            m_Animator.SetFloat("y", vertical);
            m_Animator.SetBool("moving", true);
        } else {
            m_Animator.SetBool(movingHashCode, false);
        }

        if (Input.GetButtonDown("Attack")) {
            m_Attacker.Attack(m_InputPlayer.directionSightVector, m_Attributes.attack);
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 velocityVector = new Vector2(horizontal, vertical) * m_Attributes.velocity;
        m_RigidBody2D.velocity = velocityVector;
    }
}
