using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive : MonoBehaviour {

    private Collider2D m_Collider;
    public UnityEvent OnInteracted;

    // Use this for initialization
    void Start() {
        m_Collider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (OnInteracted != null) {
            OnInteracted.Invoke();
        }
    }
}
