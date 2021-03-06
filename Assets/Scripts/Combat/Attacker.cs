﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    public float range = 1;
    public Vector2 hitBox = new Vector2(1, 1);
    public LayerMask attackLayer;
    public GameObject flashAttackVFX;

    private Vector2 vectorRangeAttack;
    private Vector2 pointA, pointB;
    private Collider2D [] attackColliders = new Collider2D[12];
    private ContactFilter2D attackFilter;
    private TextController m_TextController;

    private void Start() {
        attackFilter.layerMask = attackLayer;
        attackFilter.useLayerMask = true;
        m_TextController = GetComponent<TextController>();
    }

    private void Update() {
        Debug.DrawLine(transform.position, (Vector2)transform.position + vectorRangeAttack, Color.yellow);
        Debug.DrawLine(pointA, pointB, Color.red);
    }

    public void Attack(Vector2 attackDirection, int damage) {
        HitBoxArea(attackDirection);
        int amountOfCollision = Physics2D.OverlapArea(pointA, pointB, attackFilter, attackColliders);
        for (int i = 0 ; i < amountOfCollision ; i++) {
            Attacked newAttackedObject = attackColliders [i].gameObject.GetComponent<Attacked>();
            if(newAttackedObject != null) {
                newAttackedObject.GetAttack(attackDirection, damage);
                InstantiateFlashAttackEffect(newAttackedObject);
                CreateText(damage, newAttackedObject);
            }
        }
    }

    private void CreateText(int damage, Attacked newAttackedObject)
    {
        if (m_TextController != null) {
            m_TextController.CreateTextBehaviour(damage, newAttackedObject.transform, false);
        }
    }

    private void InstantiateFlashAttackEffect(Attacked newAttackedObject)
    {
        if (flashAttackVFX != null) {
            Instantiate(flashAttackVFX, newAttackedObject.transform);
        }
    }

    private void HitBoxArea(Vector2 attackDirection) {
        Vector2 scaleVector = transform.lossyScale;
        Vector2 hitBoxScale = Vector2.Scale(hitBox, scaleVector);
        vectorRangeAttack = Vector2.Scale(attackDirection.normalized * range, scaleVector);
        pointA = (Vector2)transform.position + vectorRangeAttack - hitBoxScale * 0.5f;
        pointB = pointA + hitBoxScale;
    }
}
