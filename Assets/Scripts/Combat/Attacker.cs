using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    public float range = 1;
    public Vector2 hitBox = new Vector2(1, 1);
    private Vector2 vectorRangeAttack;
    private Vector2 pointA, pointB;

    private void Update() {
        Debug.DrawLine(transform.position, (Vector2)transform.position + vectorRangeAttack, Color.yellow);
        Debug.DrawLine(pointA, pointB, Color.red);
    }

    public void Attack(Vector2 attackDirection, int damage) {
        vectorRangeAttack = attackDirection.normalized * range;
        pointA = (Vector2)transform.position + vectorRangeAttack - hitBox * 0.5f;
        pointB = pointA + hitBox;
    }
}
