using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class TextBehaviour : MonoBehaviour
{

    public float lifeTime = 1f;
    public float movementDistance = 2f;
    public float timeToFadeOut;
    public Color color;
    public float movementAmount;

    private TextMeshPro textLabel;
    private bool isFading;
    private float currentDistance = 0f;
    private Vector3 verticalMovementVector;
    private string sortingLayer = "Text"; //Just to follow tutorial, beacuase they use TextMesh unity default.

    void Start()
    {
        textLabel = GetComponent<TextMeshPro>();
        verticalMovementVector = new Vector3(0, movementAmount);
    }

    void Update()
    {
        if (currentDistance < movementDistance) {
            transform.localPosition += verticalMovementVector;
            currentDistance += movementAmount;
        } else {
            if (!isFading) {
                isFading = true;
                Destroy(this.gameObject, lifeTime);
                StartCoroutine(FadeOut());
            }
        }

    }

    private IEnumerator FadeOut()
    {
        Color tempColor = textLabel.color;
        for (float alpha = 1; alpha > 0; alpha -= ( 1/( lifeTime )*Time.deltaTime )) {
            tempColor.a = alpha;
            textLabel.color = tempColor;
            yield return new WaitForEndOfFrame();
        }
    }
}
