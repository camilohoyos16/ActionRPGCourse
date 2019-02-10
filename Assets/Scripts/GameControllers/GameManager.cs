using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform playerSpawnPoint;
    public GameObject playerGO;
    public static GameManager instance;

    // Use this for initialization
    void Start() {
        instance = null;
        playerGO = GameObject.FindObjectOfType<PlayerController>().gameObject;
        playerGO.transform.position = playerSpawnPoint.position;
    }

    // Update is called once per frame
    void Update() {

    }
}
