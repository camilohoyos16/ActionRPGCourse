using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Attributes m_Attributes;
    public string enemyName;
    public int xp;

    protected void GetEnemyName() {
        Debug.Log("Hello, Im " + enemyName);
    }
}
