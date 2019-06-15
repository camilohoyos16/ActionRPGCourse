using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public static MenuController instance
    {
        get;
        private set;
    }
    private CanvasGroup m_CanvasGroup;
    private bool isOpen;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        m_CanvasGroup = GetComponent<CanvasGroup>();
        HidePanel();
    }

    public void ChangePanelState()
    {
        if (isOpen) {
            HidePanel();
        } else {
            ShowPanel();
        }
    }

    private void ShowPanel()
    {
        isOpen = true;
        m_CanvasGroup.alpha = 1;
        m_CanvasGroup.blocksRaycasts = true;
        m_CanvasGroup.interactable = true;
        Time.timeScale = 0;
    }

    private void HidePanel()
    {
        isOpen = false;
        m_CanvasGroup.alpha = 0;
        m_CanvasGroup.blocksRaycasts = false;
        m_CanvasGroup.interactable = false;
        Time.timeScale = 1;
    }
}
