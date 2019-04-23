using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform playerSpawnPoint;
    public GameObject playerGO;
    public static GameManager Instance;
    public Transform tempObjectsContent;

    // Use this for initialization
    void Start() {
        Instance = this;
        playerGO = GameObject.FindObjectOfType<PlayerController>().gameObject;
        playerGO.transform.position = playerSpawnPoint.position;
    }

    // Update is called once per frame
    void Update() {

    }
}
