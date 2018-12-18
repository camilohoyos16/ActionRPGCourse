using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour {

    [HideInInspector] public float horizontalAxis;
    [HideInInspector] public float verticalAxis;
    [HideInInspector] public bool attack;
    [HideInInspector] public bool ability1;
    [HideInInspector] public bool ability2;
    [HideInInspector] public bool inventory;
    [HideInInspector] public bool interact;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        attack = Input.GetButtonDown("Attack");
        ability1 = Input.GetButtonDown("Ability1");
        ability2 = Input.GetButtonDown("Ability2");
        inventory = Input.GetButtonDown("Inventory");
        interact = Input.GetButtonDown("Interact");

        //Axis
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        Debug.LogFormat("Horizontal: {0} - Vertical: {1}", horizontalAxis, verticalAxis);
    }
}
