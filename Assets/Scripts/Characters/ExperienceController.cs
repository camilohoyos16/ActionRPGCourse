using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(TextController))]
public class ExperienceController : MonoBehaviour {

    public Image experienceBar;
    public AttributeButton[] attributeButtons;

    private TextController m_TextController;
    private Range textRange = new Range() { min = 0, max = 0 };

    private int currentExperience;
    private int nextLevelExperience;
    private float percentageCurrentLevel;
    private int level { get; set; }
    private int attributesPoints;

    public int CurrentExperience
    {
        get {
            return currentExperience;
        }

        set {
            currentExperience= value;
            if (level > 1) {
                percentageCurrentLevel = (float)( currentExperience - ExperienceCumulativeCurve(level) ) / nextLevelExperience;
                {
                    while (percentageCurrentLevel >= 1)
                    {
                        LevelUp();
                    }
                }
            } else {
                percentageCurrentLevel = (float)( currentExperience / nextLevelExperience );
                while (percentageCurrentLevel >= 1) {
                    LevelUp();
                }
            }
            UpdateExpereinceBar();
        }
    }

    private void Start()
    {
        level = 1;
        m_TextController = GetComponent<TextController>();
        nextLevelExperience = ExperienceCurve(level);
        this.UpdateExpereinceBar();
        CheckAttributeButtonsState();
    }


    private int ExperienceCurve(int level)
    {
        int experience = Mathf.CeilToInt(Mathf.Log(level, 3) + 20);
        return experience;
    }

    private int ExperienceCumulativeCurve(int level)
    {
        int experience = 0;
        for (int i = 1; i < level; i++) {
            experience += this.ExperienceCurve(i);
        }
        return experience;
    }

    private void LevelUp()
    {
        level++;
        SetNextLevel();
        m_TextController.CreateTextBehaviour("LEVEL UP!!!", this.transform, 12f, Color.cyan, textRange, textRange, 2f);
        percentageCurrentLevel = (float)( CurrentExperience - ExperienceCumulativeCurve(level) ) / nextLevelExperience;
    }

    private void SetNextLevel()
    {
        attributesPoints++;
        nextLevelExperience = ExperienceCurve(level);
        CheckAttributeButtonsState();
    }

    private void UpdateExpereinceBar()
    {
        experienceBar.fillAmount = this.percentageCurrentLevel;
    }

    public void SpendExpereincePoints()
    {
        attributesPoints--;
        CheckAttributeButtonsState();
    }

    private void CheckAttributeButtonsState()
    {
        for (int i = 0; i < attributeButtons.Length; i++) {
            attributeButtons[i].ChangeButtonState(attributesPoints);
        }
    }
}
