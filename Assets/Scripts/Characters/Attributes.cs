using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttributeType
{
    velocity,
    attack,
    health
}

[CreateAssetMenu(menuName = "Scriptables/Attributes")]
public class Attributes : ScriptableObject {

    [Tooltip("Movement velocity")]
    [SerializeField] private int baseVelocity;
    [SerializeField]  private int baseAttack;

    private int velocityModifier;
    private int attackModifier;

    public int velocity { get { return baseVelocity + velocityModifier; } }
    public int attack { get { return baseAttack + attackModifier; } }

    public void ChangeBaseVelocity(int value)
    {
        baseVelocity += value;
    }

    public void ChangeBaseAttack(int value)
    {
        baseAttack += value;
    }

    public void ChangeAttribute(AttributeType attributeType, int value)
    {
        switch (attributeType) {
            case AttributeType.velocity:
                velocityModifier += value;
                break;
            case AttributeType.attack:
                attackModifier += value;
                break;
            case AttributeType.health:

                break;
            default:
                break;
        }
    }
    
    private void ChangeHealthModifier(Health health, int value)
    {
        health.healthModifier += value;
    }
}
