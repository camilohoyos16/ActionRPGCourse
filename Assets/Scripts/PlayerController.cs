using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocity;

    private float horizontal;
    private float vertical;
    private InputPlayer playerInputInstance;
    private Transform m_Transform;
    private Rigidbody2D m_RigidBody2D;

	// Use this for initialization
	void Start () {
        playerInputInstance = GetComponent<InputPlayer>();
        m_Transform = GetComponent<Transform>();
        m_RigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = playerInputInstance.horizontalAxis;
        vertical = playerInputInstance.verticalAxis;
    }

    // Update is called once per frame
    void FixedUpdate() {

        Vector2 velocityVector = new Vector2(horizontal, vertical) * velocity;
        //m_RigidBody2D.AddForce(force);
        m_RigidBody2D.velocity = velocityVector;
    }
}
