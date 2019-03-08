using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{

    public Transform player;

    public float vertical
    {
        get {
            return directionToPlayer.y;
        }
    }

    public float horizontal
    {
        get {
            return directionToPlayer.x;
        }
    }

    public float playerDistance
    {
        get {
            return directionToPlayer.magnitude;
        }
    }

    public Vector2 directionToPlayer
    {
        get;

        private set;
    }

    // Use this for initialization
    void Start()
    {
        GetDirectionToPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionToPlayer();
    }

    private void GetDirectionToPlayer()
    {
        if(player != null) {
            directionToPlayer = player.position - transform.position;
        }
    }
}
