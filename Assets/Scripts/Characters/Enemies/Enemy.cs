using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Attributes m_Attributes;
    public string enemyName;
    public int experience;
    public GameObject spawnVFX;

    protected void GetEnemyName() {
        Debug.Log("Hello, Im " + enemyName);
    }

    public void GiveExpereince()
    {
        GameManager.Instance.playerGO.GetComponent<ExperienceController>().CurrentExperience += this.experience;
    }
}
