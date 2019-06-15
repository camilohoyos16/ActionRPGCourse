using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class InputPlayer : MonoBehaviour {

    public float horizontalAxis { get; private set; }
    public float verticalAxis { get; private set; }
    public bool attack { get; private set; }
    public bool ability1 { get; private set; }
    public bool ability2 { get; private set; }
    public bool menu { get; private set; }
    public bool interact { get; private set; }
    [HideInInspector] public Vector2 directionSightVector;

    private void Awake() {
        directionSightVector = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update() {
        attack = Input.GetButtonDown("Attack");
        ability1 = Input.GetButtonDown("Ability1");
        ability2 = Input.GetButtonDown("Ability2");
        menu = Input.GetButtonDown("Menu");
        interact = Input.GetButtonDown("Interact");

        //Axis
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        DirectionSightVector();
    }

    private void DirectionSightVector() {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
            directionSightVector.x = horizontalAxis;
            directionSightVector.y = verticalAxis;
        }
    }
}
