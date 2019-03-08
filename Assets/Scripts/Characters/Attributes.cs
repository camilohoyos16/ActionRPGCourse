using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Attributes")]
public class Attributes : ScriptableObject {

    [Tooltip ("Movement velocity")]
    public int velocity;
    public int attack;
}
