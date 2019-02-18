using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Attacked : MonoBehaviour {

    private Health m_Health;
    private Rigidbody2D m_Rigidbody2D;

    private void Start() {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Health = GetComponent<Health>();
    }

    public void GetAttack() {
        m_Health.CurrentHealth -= 1;
    }

    public void GetAttack(Vector2 attackDirection, int damage) {
        m_Health.SetCurrentHealt(-damage);
        m_Rigidbody2D.AddForce(attackDirection * damage * 100);
    }
}
