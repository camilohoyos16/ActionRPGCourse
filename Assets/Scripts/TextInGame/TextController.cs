using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class TextController : MonoBehaviour {

    public TextBehaviour m_TextBehaviour;
    private Range rangeOffsetXDefault = new Range();
    private Range rangeOffsetYDefault = new Range();
    private Color defaultColor;
    private float defaultLifeTime = 1;
    private float defaultSize = 10;

    private void Start()
    {
        defaultColor = Color.white;
    }

    public void CreateTextBehaviour(string text, Transform parent, float size, Color color, 
        Range rangeOffsetX, Range rangeOffsetY, float lifeTime, bool attachedToParent = true)
    {
        Vector3 offset = new Vector2(Random.Range(rangeOffsetX.min, rangeOffsetX.max), Random.Range(rangeOffsetY.min, rangeOffsetY.max));
        Transform parentToAttached = attachedToParent ? parent : GameManager.Instance.tempObjectsContent;
        TextBehaviour textBehaviour = Instantiate(m_TextBehaviour, parent.position + offset, Quaternion.identity, parentToAttached);
        textBehaviour.lifeTime = lifeTime;
        textBehaviour.textLabel.color = color;
        textBehaviour.textLabel.fontSize = size;
        textBehaviour.textLabel.text = text;
    }

    public void CreateTextBehaviour(float value, Transform parent, float size, Color color,
        Range rangeOffsetX, Range rangeOffsetY, float lifeTime, bool attachedToParent = true)
    {
        CreateTextBehaviour(value.ToString(), parent, size, color, rangeOffsetX, rangeOffsetY, lifeTime, attachedToParent);
    }

    public void CreateTextBehaviour(float value, Transform parent, float size, Color color, bool attachedToParent = true)
    {
        CreateTextBehaviour(value.ToString(), parent, size, color, rangeOffsetXDefault, rangeOffsetYDefault, defaultLifeTime, attachedToParent);
    }

    public void CreateTextBehaviour(float value, GameObject parent, bool attachedToParent = true)
    {
        CreateTextBehaviour(value.ToString(), parent.transform, attachedToParent);
    }

    public void CreateTextBehaviour(float value, Transform parent, bool attachedToParent = true)
    {
        CreateTextBehaviour(value.ToString(), parent, attachedToParent);
    }

    public void CreateTextBehaviour(string text, GameObject parent, bool attachedToParent = true)
    {
        CreateTextBehaviour(text, parent.transform, attachedToParent);
    }

    public void CreateTextBehaviour(string text, Transform parent, bool attachedToParent = true)
    {
        CreateTextBehaviour(text, parent, defaultSize, defaultColor, rangeOffsetXDefault, rangeOffsetYDefault, defaultLifeTime, attachedToParent);
    }

    public void CreateTextBehaviour(string text, bool attachedToParent = true)
    {
        CreateTextBehaviour(text, this.transform, defaultSize, defaultColor, rangeOffsetXDefault, rangeOffsetYDefault, defaultLifeTime, attachedToParent);
    }
}
