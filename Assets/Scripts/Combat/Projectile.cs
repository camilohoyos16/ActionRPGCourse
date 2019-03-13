using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{

    public float initialVelocity;
    public Vector2 initialDirection;
    public int damage;
    private Rigidbody2D m_Rigidbody2D;
    public string targetTag;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.velocity = initialDirection.normalized * initialVelocity;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag)) {
            collision.gameObject.GetComponent<Attacked>().GetAttack(initialDirection, damage);
            Destroy(gameObject);
        }
    }
}
